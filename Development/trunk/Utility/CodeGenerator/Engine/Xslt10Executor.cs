using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using System.Xml;
using System.IO;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public class Xslt10Executor
    {
        public void Execute(string metaFilePath, string xsltFilePath, string targetFilePath, XsltArgumentList args)
        {
            if (metaFilePath == null)
            {
                throw new ArgumentNullException("metaFilePath");
            }
            if (xsltFilePath == null)
            {
                throw new ArgumentNullException("xsltFilePath");
            }
            if (targetFilePath == null)
            {
                throw new ArgumentNullException("targetFilePath");
            }

            string targetDir = Path.GetDirectoryName(targetFilePath);
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            using (Stream xslt = new FileStream(xsltFilePath, FileMode.Open))
            {
                XsltSettings settings = new XsltSettings(false, true);
                XslCompiledTransform tr = new XslCompiledTransform(true);
                XmlReader xr = new XmlTextReader(xsltFilePath, xslt);
                tr.Load(xr, settings, new XmlUrlResolver());
                StreamWriter sw = new StreamWriter(targetFilePath, false);
                tr.Transform(metaFilePath, args, sw);
            }
        }

        public void Execute(string metaFilePath, string xsltFilePath, string targetFilePath)
        {
            this.Execute(metaFilePath, xsltFilePath, targetFilePath, null);
        }

        public void ExecuteFromConfig()
        {
            this.ExecuteFromConfig(null);
        }

        public void ExecuteFromConfig(CodeGeneratorSection config)
        {
            if (config == null)
            {
                config = Initializer.ConfigRoot;
            }

            foreach (ProcessingEntryElement procElement in config.ProcessEntries.GetAllProcessingEntries())
            {
                XsltArgumentList args = new XsltArgumentList();
                if (config.DefaultSettings != null)
                {
                    if (config.DefaultSettings.Global != null)
                    {
                        this.FillXsltArguments(args, config.DefaultSettings.Global);
                    }
                    if (config.DefaultSettings.XsltMappings != null)
                    {
                        DefaultSettingSetElement dftSettingByXslt = config.DefaultSettings.XsltMappings.GetDefaultSetByXsltExactPath(procElement.ExactXsltFilePath);
                        if (dftSettingByXslt != null)
                        {
                            this.FillXsltArguments(args, dftSettingByXslt);
                        }
                    }
                }
                if (procElement.Parent != null)
                {
                    this.FillParametersToXsltArguments(args, procElement.Parent.SharedParameters);
                }
                this.FillParametersToXsltArguments(args, procElement.Parameters);

                this.Execute(procElement.ExactSourceFilePath, procElement.ExactXsltFilePath, procElement.ExactTargetFileFath, args);
            }
        }

        private void FillXsltArguments(XsltArgumentList args, DefaultSettingSetElement defaultSet)
        {
            this.FillExtentionsToXsltArguments(args, defaultSet.Extensions);
            this.FillParametersToXsltArguments(args, defaultSet.Parameters);
        }

        private void FillExtentionsToXsltArguments(XsltArgumentList args, ExtentionElementCollection extensions)
        {
            if (extensions != null)
            {
                foreach (ExtentionElement ext in extensions)
                {
                    args.RemoveExtensionObject(ext.Namespace);
                    Type t = Type.GetType(ext.Type, false);
                    if (t != null)
                    {
                        object obj = null;
                        if (!t.IsAbstract)
                        {
                            obj = Activator.CreateInstance(t);
                        }
                        args.AddExtensionObject(ext.Namespace, obj);
                    }
                }
            }
        }

        private void FillParametersToXsltArguments(XsltArgumentList args, ParameterElementCollection parameters)
        {
            if (parameters != null)
            {
                foreach (ParameterElement para in parameters)
                {
                    args.RemoveParam(para.Name, para.Namespace);
                    args.AddParam(para.Name, para.Namespace, para.Value);
                }
            }
        }
    }
}
