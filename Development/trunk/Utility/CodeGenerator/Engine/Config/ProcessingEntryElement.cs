using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Wang.Velika.Utility.GeneralLibrary;
using System.IO;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public class ProcessingEntryElement : ConfigurationElement
    {
        internal ProcessingEntryElementCollection Parent { get; private set; }


        public ProcessingEntryElement()
        {
        }

        public ProcessingEntryElement(ProcessingEntryElementCollection parent)
            : this()
        {
            this.Parent = parent;
        }


        [ConfigurationProperty("sourceFilePath", IsRequired = true)]
        public string SourceFilePath
        {
            get
            {
                return (string)this["sourceFilePath"];
            }
            set
            {
                this["sourceFilePath"] = value;
            }
        }

        [ConfigurationProperty("xsltFilePath", IsRequired = true)]
        public string XsltFilePath
        {
            get
            {
                return (string)this["xsltFilePath"];
            }
            set
            {
                this["xsltFilePath"] = value;
            }
        }

        [ConfigurationProperty("targetFilePath", IsRequired = true)]
        public string TargetFilePath
        {
            get
            {
                return (string)this["targetFilePath"];
            }
            set
            {
                this["targetFilePath"] = value;
            }
        }

        [ConfigurationProperty("parameters")]
        public ParameterElementCollection Parameters
        {
            get
            {
                return (ParameterElementCollection)this["parameters"];
            }
            set
            {
                this["parameters"] = value;
            }
        }


        public string ExactSourceFilePath
        {
            get
            {
                string ret = this.SourceFilePath;
                if ((this.Parent != null) && !String.IsNullOrEmpty(this.Parent.SourceFileBasePath))
                {
                    ret = Path.Combine(this.Parent.SourceFileBasePath, ret);
                }
                if ((this.Parent != null) && (this.Parent.Parent != null) && !String.IsNullOrEmpty(this.Parent.Parent.SourceFileBasePath))
                {
                    ret = Path.Combine(this.Parent.Parent.SourceFileBasePath, ret);
                }
                ret = ConfigurationHelper.CalculatePathRelativeToConfigurationFile(this, ret);

                return ret;
            }
        }

        public string ExactXsltFilePath
        {
            get
            {
                string ret = this.XsltFilePath;
                if ((this.Parent != null) && (this.Parent.Parent != null) && !String.IsNullOrEmpty(this.Parent.Parent.XsltFileBasePath))
                {
                    ret = Path.Combine(this.Parent.Parent.XsltFileBasePath, ret);
                }
                ret = ConfigurationHelper.CalculatePathRelativeToConfigurationFile(this, ret);

                return ret;
            }
        }

        public string ExactTargetFileFath
        {
            get
            {
                string ret = this.TargetFilePath;
                if ((this.Parent != null) && !String.IsNullOrEmpty(this.Parent.TargetFileBasePath))
                {
                    ret = Path.Combine(this.Parent.TargetFileBasePath, ret);
                }
                ret = ConfigurationHelper.CalculatePathRelativeToConfigurationFile(this, ret);

                return ret;
            }
        }
    }
}
