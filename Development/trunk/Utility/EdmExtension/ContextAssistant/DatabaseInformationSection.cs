using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Wang.Velika.Utility.EdmExtension
{
    public class DatabaseInformationSection : ConfigurationSection
    {
        [ConfigurationProperty("provider", IsRequired = true)]
        public String Provider
        {
            get
            {
                return (String)this["provider"];
            }
            set
            {
                this["provider"] = value;
            }
        }

        [ConfigurationProperty("connectionString", IsRequired = true)]
        public String ConnectionString
        {
            get
            {
                return (String)this["connectionString"];
            }
            set
            {
                this["connectionString"] = value;
            }
        }

        [ConfigurationProperty("timeout")]
        public TimeSpan? Timeout
        {
            get
            {
                return (TimeSpan?)this["timeout"];
            }
            set
            {
                this["timeout"] = value;
            }
        }
    }
}
