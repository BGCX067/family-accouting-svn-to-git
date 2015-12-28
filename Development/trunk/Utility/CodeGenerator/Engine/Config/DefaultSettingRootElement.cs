using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public class DefaultSettingRootElement : ConfigurationElement
    {
        public DefaultSettingRootElement()
        {
        }
        [ConfigurationProperty("global")]
        public DefaultSettingSetElement Global
        {
            get
            {
                return (DefaultSettingSetElement)this["global"];
            }
            set
            {
                this["global"] = value;
            }
        }

        [ConfigurationProperty("xsltMappings")]
        public DefaultSettingSetElementByXsltCollection XsltMappings
        {
            get
            {
                return (DefaultSettingSetElementByXsltCollection)this["xsltMappings"];
            }
            set
            {
                this["xsltMappings"] = value;
            }
        }
    }
}
