using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public class DefaultSettingSetElement : ConfigurationElement
    {
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

        [ConfigurationProperty("extensions")]
        public ExtentionElementCollection Extensions
        {
            get
            {
                return (ExtentionElementCollection)this["extensions"];
            }
            set
            {
                this["extensions"] = value;
            }
        }
    }
}
