using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.Utility.GeneralLibrary;
using System.Configuration;

namespace Wang.Velika.Utility.WCFExtension
{
    public class WsdlHeaderBindingElement : ExtendedConfigurationElement
    {
        [ConfigurationProperty("enabled", DefaultValue = false)]
        public bool Enabled
        {
            get
            {
                return (bool)this["enabled"];
            }
            set
            {
                this["enabled"] = value;
            }
        }

        [ConfigurationProperty("isRequired", DefaultValue = false)]
        public bool IsRequired
        {
            get
            {
                return (bool)this["isRequired"];
            }
            set
            {
                this["isRequired"] = value;
            }
        }
    }
}
