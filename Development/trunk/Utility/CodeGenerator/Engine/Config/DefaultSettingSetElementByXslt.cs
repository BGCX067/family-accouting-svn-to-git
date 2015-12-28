using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Wang.Velika.Utility.GeneralLibrary;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public class DefaultSettingSetElementByXslt : DefaultSettingSetElement
    {
        [ConfigurationProperty("xsltFilePathes", IsRequired = true)]
        public string XsltFilePathes
        {
            get
            {
                return (string)this["xsltFilePathes"];
            }
            set
            {
                this["xsltFilePathes"] = value;
            }
        }


        public string[] GetExactXsltFilePathes()
        {
            string[] pathes = this.XsltFilePathes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> ret = new List<string>();
            foreach (string path in pathes)
            {
                string str = path.Trim();
                if (!String.IsNullOrEmpty(str))
                {
                    ret.Add(ConfigurationHelper.CalculatePathRelativeToConfigurationFile(this, str));
                }
            }

            return ret.ToArray();
        }
    }
}
