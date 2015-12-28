using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Specialized;
using Wang.Velika.Utility.ParameterChecking;
using Wang.Velika.Utility.ParameterChecking.Validators;
using Parameter = Wang.Velika.Utility.ParameterChecking.Parameter;
using System.IO;

namespace Wang.Velika.Utility.DBSchemaRetriever.MSSQL
{
    internal class Sql2005Scripter
    {
        private const string SCRIPT_FILE_EXTENSION = ".sql";
        private static readonly ScriptingOptions SCRIPTING_OPTIONS_FOR_SCRIPTING = ScriptOption.Default + ScriptOption.NoCollation + ScriptOption.NoFileGroup;
        private static readonly ScriptingOptions SCRIPTING_OPTIONS_FOR_FOREIGNKEY_SCRIPTING = ScriptOption.NoCollation + ScriptOption.NoFileGroup + ScriptOption.DriForeignKeys;
        private const string SCRIPT_ENDING_STATEMENT = "GO";


        private ParameterCollection _parameters;
        private ParameterCollection Parameters
        {
            get
            {
                if (this._parameters == null)
                {
                    this._parameters = new ParameterCollection();
                    this._parameters.Add(new Parameter("dbServer", "server", true, null, new NotEmptyValidator()));
                    this._parameters.Add(new Parameter("database", "database", true, null, new NotEmptyValidator()));
                    this._parameters.Add(new Parameter("tableScriptPath", "table", true, null, new NotEmptyValidator()));
                    this._parameters.Add(new Parameter("indexScriptPath", "index", true, null, new NotEmptyValidator()));
                    this._parameters.Add(new Parameter("foreignKeyScriptPath", "fk", true, null, new NotEmptyValidator()));
                    this._parameters.Add(new Parameter("storedProcedureScriptPath", "sp", false, null, new NotEmptyValidator()));
                }
                return this._parameters;
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

        private string TableScriptPath
        {
            get
            {
                return this.Parameters["tableScriptPath"].Value;
            }
        }

        private string IndexScriptPath
        {
            get
            {
                return this.Parameters["indexScriptPath"].Value;
            }
        }

        private string ForeignKeyScriptPath
        {
            get
            {
                return this.Parameters["foreignKeyScriptPath"].Value;
            }
        }

        private string StoredProcedureScriptPath
        {
            get
            {
                string ret = null;
                if (this.Parameters.ContainsKey("storedProcedureScriptPath"))
                {
                    ret = this.Parameters["storedProcedureScriptPath"].Value;
                }

                return ret;
            }
        }

        private TextWriter logger;


        internal Sql2005Scripter(string argumentsText, TextWriter logger)
        {
            this.logger = logger;

            List<Parameter> errs;
            this.Parameters.ParseFromText(argumentsText, ParseParameterTextMode.SlashNameColonValue, out errs);
            if ((errs != null) && (errs.Count > 0))
            {
                //TODO: Write error mesage.
            }
        }

        internal void Run()
        {
            SqlConnectionInfo sci = this.CreateConnectionInfo();
            ServerConnection sc = new ServerConnection(sci);
            Server s = new Server(sc);
            Database db = s.Databases[this.Database];

            this.CleanFolder(this.TableScriptPath);
            this.CleanFolder(this.IndexScriptPath);
            this.CleanFolder(this.ForeignKeyScriptPath);
            if (this.StoredProcedureScriptPath != null)
            {
                this.CleanFolder(this.StoredProcedureScriptPath);
            }
            this.ParseDatabase(db);
        }

        private SqlConnectionInfo CreateConnectionInfo()
        {
            SqlConnectionInfo ret = new SqlConnectionInfo(this.DBServer);
            ret.ApplicationName = this.GetType().FullName;

            return ret;
        }

        private void ParseDatabase(Database db)
        {
            this.logger.WriteLine(String.Format("Starting inspect database {0}.", db));
            foreach (Table t in db.Tables)
            {
                this.logger.WriteLine(String.Format("Inspecting table {0}...", t));
                if (t.IsSystemObject)
                {
                    this.logger.WriteLine(String.Format("{0} is system object. Skipped.", t));
                }
                else
                {
                    List<StringCollection> tableScripts = new List<StringCollection>();
                    tableScripts.Add(t.Script(SCRIPTING_OPTIONS_FOR_SCRIPTING));
                    this.WriteScriptFile(this.TableScriptPath, t.Name, tableScripts.ToArray());

                    foreach (Index idx in t.Indexes)
                    {
                        this.logger.WriteLine(String.Format("Inspecting index {0}...", idx));
                        List<StringCollection> indexScripts = new List<StringCollection>();
                        indexScripts.Add(idx.Script(SCRIPTING_OPTIONS_FOR_SCRIPTING));
                        //this.WriteScriptFile(this.IndexScriptPath, String.Format("{0} - {1}", t.Name, idx.Name), indexScripts.ToArray());
                        this.WriteScriptFile(this.IndexScriptPath, idx.Name, indexScripts.ToArray());
                    }

                    foreach (ForeignKey fk in t.ForeignKeys)
                    {
                        this.logger.WriteLine(String.Format("Inspecting foreign key {0}...", fk));
                        StringCollection fkScripts = fk.Script(SCRIPTING_OPTIONS_FOR_FOREIGNKEY_SCRIPTING);
                        this.WriteScriptFile(this.ForeignKeyScriptPath, fk.Name, new StringCollection[] {fkScripts});
                    }
                }
            }
            if (this.StoredProcedureScriptPath != null)
            {
                foreach (StoredProcedure sp in db.StoredProcedures)
                {
                    this.logger.WriteLine(String.Format("Inspecting stored procedure {0}...", sp));
                    if (sp.IsSystemObject)
                    {
                        this.logger.WriteLine(String.Format("{0} is system object. Skipped.", sp));
                    }
                    else
                    {
                        StringCollection spScripts = sp.Script(SCRIPTING_OPTIONS_FOR_SCRIPTING);
                        this.WriteScriptFile(this.StoredProcedureScriptPath, sp.Name, new StringCollection[] { spScripts });
                    }
                }
            }
            this.logger.WriteLine(String.Format("Completed generate scrits from database {0}.", db));
        }

        private void CleanFolder(string path)
        {
            this.logger.WriteLine(String.Format("Cleaning folder '{0}'.", path));
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo fi in di.GetFiles("*" + SCRIPT_FILE_EXTENSION))
            {
                if ((fi.Attributes & FileAttributes.Hidden) == 0)
                {
                    fi.Delete();
                }
            }
        }

        private void WriteScriptFile(string path, string objectName, StringCollection[] scripts)
        {
            string fullPath = Path.Combine(path, objectName) + SCRIPT_FILE_EXTENSION;
            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                foreach (StringCollection strs in scripts)
                {
                    foreach (string script in strs)
                    {
                        sw.WriteLine(script);
                        sw.WriteLine(SCRIPT_ENDING_STATEMENT);
                    }
                }

                sw.Flush();
                sw.Close();
            }
            this.logger.WriteLine(String.Format("wrote file {0}.", path));
        }
    }
}
