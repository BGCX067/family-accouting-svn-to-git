using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public class ProcessingEntryElementRoot : ConfigurationElementCollection
    {
        [ConfigurationProperty("xsltFileBasePath")]
        public string XsltFileBasePath
        {
            get
            {
                return (string)this["xsltFileBasePath"];
            }
            set
            {
                this["xsltFileBasePath"] = value;
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


        public ProcessingEntryElementRoot()
        {
            this.AddElementName = "processEntryGroup";
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new ProcessingEntryElementCollection(this);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProcessingEntryElementCollection)element).Name;
        }


        public IList<ProcessingEntryElement> GetAllProcessingEntries()
        {
            IList<ProcessingEntryElement> ret = new List<ProcessingEntryElement>();
            foreach (ProcessingEntryElementCollection group in this)
            {
                foreach (ProcessingEntryElement entry in group)
                {
                    ret.Add(entry);
                }
            }

            return ret;
        }
    }
}
