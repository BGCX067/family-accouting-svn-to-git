using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public class ExtentionElement : ConfigurationElement
    {
        [ConfigurationProperty("namespace", IsRequired = true)]
        public string Namespace
        {
            get
            {
                return (string)this["namespace"];
            }
            set
            {
                this["namespace"] = value;
            }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get
            {
                return (string)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }
    }
}
