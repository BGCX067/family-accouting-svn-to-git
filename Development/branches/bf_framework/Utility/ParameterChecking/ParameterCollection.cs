using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace Wang.Velika.Utility.ParameterChecking
{
    public class ParameterCollection : Dictionary<string, Parameter>
    {
        private const string PARSE_TEXT_PATTERN_SLASHNAMECOLONVALUE = @"/(?<name>\w+)(?:\:(?<value>[^/]+))?";


        public void Add(Parameter param)
        {
            if (param != null)
            {
                this.Add(param.Name, param);
            }
        }

        public void ParseFromText(string text, ParseParameterTextMode mode, out List<Parameter> errs)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            MatchCollection ms = Regex.Matches(text, PARSE_TEXT_PATTERN_SLASHNAMECOLONVALUE);
            StringDictionary paras = new StringDictionary();
            foreach (Match m in ms)
            {
                string name = m.Groups["name"].Value.Trim();
                string value = null;
                if (m.Groups["value"] != null)
                {
                    value = m.Groups["value"].Value.Trim();
                }
                paras.Add(name, value);
            }
            foreach (KeyValuePair<string, Parameter> kvp in this)
            {
                kvp.Value.InitValueFrom(paras);
            }
            this.Validate(out errs);
        }

        public bool Validate(out List<Parameter> errs)
        {
            bool ret = true;
            errs = new List<Parameter>();
            foreach (KeyValuePair<string, Parameter> kvp in this)
            {
                if (!kvp.Value.Validate())
                {
                    errs.Add(kvp.Value);
                    ret = false;
                }
            }
            return ret;
        }
    }
}
