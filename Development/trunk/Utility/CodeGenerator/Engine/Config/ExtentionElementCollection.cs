using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public class ExtentionElementCollection : ConfigurationElementCollection
    {
        public ExtentionElementCollection()
        {
            this.AddElementName = "extension";
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new ExtentionElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ExtentionElement)element).Namespace;
        }
    }
}
