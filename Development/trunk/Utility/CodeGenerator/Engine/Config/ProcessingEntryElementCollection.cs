using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public class ProcessingEntryElementCollection : ConfigurationElementCollection
    {
        internal ProcessingEntryElementRoot Parent { get; private set; }

        [ConfigurationProperty("name")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("sourceFileBasePath")]
        public string SourceFileBasePath
        {
            get
            {
                return (string)this["sourceFileBasePath"];
            }
            set
            {
                this["sourceFileBasePath"] = value;
            }
        }

        [ConfigurationProperty("targetFileBasePath")]
        public string TargetFileBasePath
        {
            get
            {
                return (string)this["targetFileBasePath"];
            }
            set
            {
                this["targetFileBasePath"] = value;
            }
        }

        [ConfigurationProperty("sharedParameters")]
        public ParameterElementCollection SharedParameters
        {
            get
            {
                return (ParameterElementCollection)this["sharedParameters"];
            }
            set
            {
                this["sharedParameters"] = value;
            }
        }


        public ProcessingEntryElementCollection()
        {
            this.AddElementName = "processEntry";
        }

        public ProcessingEntryElementCollection(ProcessingEntryElementRoot parent)
            : this()
        {
            this.Parent = parent;
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new ProcessingEntryElement(this);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProcessingEntryElement)element).ExactTargetFileFath;
        }
    }
}
