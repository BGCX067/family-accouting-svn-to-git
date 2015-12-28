using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.Utility.ParameterChecking;
using Wang.Velika.Utility.ParameterChecking.Validators;
using System.IO;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Collections;
using System.Text.RegularExpressions;

namespace Wang.Velika.Utility.DBScriptRunner.MSSQL
{
    internal class SqlCmdRunner
    {
        private const string TEMPFILE_NAME_FOR_CREATE_DATABASE = "TempScript_CreateDatabase.sql";
        private static readonly string[] SCRIPTS_TEMPLATE_FOR_CREATE_DATABASE = new string[] {
            "use [master]",
            @"if exists(select * from sys.databases where name = '{0}')
begin
    alter database [{0}] set SINGLE_USER with rollback immediate
    drop database {0}
end",
            "create database {0}"
        };
        private const string SCRIPT_FILE_REQUIRED_REGEX_PATTERN = @".+\.sql$";


        private ParameterCollection _parameters;
        private ParameterCollection Parameters
        {
            get
            {
                if (this._parameters == null)
                {
                    this._parameters = new ParameterCollection();
                    this._parameters.Add(new Parameter("dbUtilityPath", "utility", true, null, new NotEmptyValidator()));
                    this._parameters.Add(new Parameter("dbServer", "server", true, null, new NotEmptyValidator()));
                    this._parameters.Add(new Parameter("database", "database", true, null, new NotEmptyValidator()));
                    this._parameters.Add(new Parameter("scriptRootPath", "script", true, null, new NotEmptyValidator()));
                    this._parameters.Add(new Parameter("logFilePath", "log", false, null, new NotEmptyValidator()));
                    this._parameters.Add(new Parameter("isCreate", "create"));
                }
                return this._parameters;
            }
        }

        private string DBUtilityPath
        {
            get
            {
                return this.Parameters["dbUtilityPath"].Value;
            }
        }

        private string DBServer
        {
            get
            {
                return this.Parameters["dbServer"].Value;
            }
        }

        private string Database
        {
            get
            {
                return this.Parameters["database"].Value;
            }
        }

        private string ScriptRootPath
        {
            get
            {
                return this.Parameters["scriptRootPath"].Value;
            }
        }

        private string LogFilePath
        {
            get
            {
                string ret = null;
                if (this.Parameters.ContainsKey("logFilePath"))
                {
                    ret = this.Parameters["logFilePath"].Value;
                }
                return ret;
            }
        }

        private bool IsCreate
        {
            get
            {
                return this.Parameters.ContainsKey("isCreate");
            }
        }


        private List<FileInfo> cachedFiles;


        internal SqlCmdRunner(string argumentsText)
        {
            List<Parameter> errs;
            this.Parameters.ParseFromText(argumentsText, ParseParameterTextMode.SlashNameColonValue, out errs);
            if ((errs != null) && (errs.Count > 0))
            {
                //TODO: Write error mesage.
            }            
        }

        internal int Run()
        {
            this.cachedFiles = new List<FileInfo>();
            if (Directory.Exists(this.ScriptRootPath))
            {
                this.ProcessDirectory(new DirectoryInfo(this.ScriptRootPath));
            }
            else if (File.Exists(this.ScriptRootPath))
            {
                this.ProcessFile(new FileInfo(this.ScriptRootPath));
            }
            else
            {
                //TODO: Throw Exception.
            }

            return this.ExecuteCachedFiles();
        }

        private void ProcessDirectory(DirectoryInfo di)
        {
            FileSystemInfo[] fsis = di.GetFileSystemInfos();
            Array.Sort<FileSystemInfo>(fsis, (fsi1, fsi2) => String.Compare(fsi1.Name, fsi2.Name));
            foreach (FileSystemInfo fsi in fsis)
            {
                if (fsi is DirectoryInfo)
                {
                    if ((fsi.Attributes & FileAttributes.Hidden) == 0)
                    {
                        this.ProcessDirectory((DirectoryInfo)fsi);
                    }
                }
                else
                {
                    this.ProcessFile((FileInfo)fsi);
                }
            }
        }

        private void ProcessFile(FileInfo fi)
        {
            if (Regex.IsMatch(fi.Name, SCRIPT_FILE_REQUIRED_REGEX_PATTERN))
            {
                this.cachedFiles.Add(fi);
            }
        }

        private int ExecuteCachedFiles()
        {
            int ret = 0;
            List<ProcessStartInfo> procs = new List<ProcessStartInfo>();
            if (this.IsCreate)
            {
                procs.Add(this.CreateProcessForCreateDB());
            }
            foreach (FileInfo fi in this.cachedFiles)
            {
                procs.Add(this.CreateProcessForScript(fi));
            }

            ret = this.RunProcesss(procs.ToArray());

            this.cachedFiles = null;
            return ret;
        }

        private ProcessStartInfo CreateProcessForCreateDB()
        {
            List<KeyValuePair<string, object>> paras = this.GenerateCommonParameters();
            StringBuilder sb = new StringBuilder();
            foreach (string cmd in SCRIPTS_TEMPLATE_FOR_CREATE_DATABASE)
            {
                if (sb.Length > 0)
                {
                    sb.Append(";");
                }
                sb.AppendFormat(cmd, this.Database);
            }
            paras.Add(new KeyValuePair<string, object>("-Q", String.Format("\"{0}\"", sb)));

            return this.CreateDBUtilityStartInfo(paras);
        }

        private ProcessStartInfo CreateProcessForScript(IList<FileInfo> files)
        {
            List<KeyValuePair<string, object>> paras = this.GenerateCommonParameters();
            paras.Add(new KeyValuePair<string, object>("-d", this.Database));
            StringBuilder sb = new StringBuilder();
            foreach (FileInfo fi in files)
            {
                if (sb.Length > 0)
                {
                    sb.Append(",");
                }
                sb.AppendFormat("\"{0}\"", fi.FullName);
            }
            paras.Add(new KeyValuePair<string, object>("-i", sb));

            return this.CreateDBUtilityStartInfo(paras);
        }

        private ProcessStartInfo CreateProcessForScript(FileInfo file)
        {
            return this.CreateProcessForScript(new FileInfo[] { file });
        }

        private ProcessStartInfo CreateProcessForScript()
        {
            return this.CreateProcessForScript(this.cachedFiles);
        }

        private List<KeyValuePair<string, object>> GenerateCommonParameters()
        {
            List<KeyValuePair<string, object>> ret = new List<KeyValuePair<string, object>>();
            ret.Add(new KeyValuePair<string, object>("-E", null));
            ret.Add(new KeyValuePair<string, object>("-S", this.DBServer));
            ret.Add(new KeyValuePair<string, object>("-H", this.GetType().FullName));
            ret.Add(new KeyValuePair<string, object>("-b", null));
            ret.Add(new KeyValuePair<string, object>("-X", 1));
            if (this.LogFilePath == null)
            {
                ret.Add(new KeyValuePair<string, object>("-e", null));
            }
            else
            {
                ret.Add(new KeyValuePair<string, object>("-o", String.Format("\"{0}\"", this.LogFilePath)));
            }

            return ret;
        }

        private ProcessStartInfo CreateDBUtilityStartInfo(List<KeyValuePair<string, object>> paras)
        {
            ProcessStartInfo ret = new ProcessStartInfo(this.DBUtilityPath);
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, object> kvp in paras)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }
                if (kvp.Value == null)
                {
                    sb.Append(kvp.Key);
                }
                else
                {
                    sb.AppendFormat("{0} {1}", kvp.Key, kvp.Value);
                }
            }
            ret.Arguments = sb.ToString();
            ret.UseShellExecute = false;

            return ret;
        }

        private int RunProcesss(ProcessStartInfo[] psis)
        {
            int ret = 0;
            foreach (ProcessStartInfo psi in psis)
            {
                Process p = new Process();
                p.StartInfo = psi;
                p.Start();
                p.WaitForExit();
                if (p.ExitCode != 0)
                {
                    ret = p.ExitCode;
                    // Exception handling.
                    break;
                }
            }

            return ret;
        }
    }
}
