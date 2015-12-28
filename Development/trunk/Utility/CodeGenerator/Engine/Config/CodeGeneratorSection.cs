using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public class CodeGeneratorSection : ConfigurationSection
    {
        [ConfigurationProperty("processEntries")]
        public ProcessingEntryElementRoot ProcessEntries
        {
            get
            {
                return (ProcessingEntryElementRoot)this["processEntries"];
            }
            set
            {
                this["processEntries"] = value;
            }
        }

        [ConfigurationProperty("defaultSettings")]
        public DefaultSettingRootElement DefaultSettings
        {
            get
            {
                return (DefaultSettingRootElement)this["defaultSettings"];
            }
            set
            {
                this["defaultSettings"] = value;
            }
        }
    }
}
