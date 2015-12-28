using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public sealed class XsltHelper
    {
        public const string XPATH_FUNCTOPN_PREFIX = "func";


        public static string ToCamelCase(string str)
        {
            string ret = str;
            if (!String.IsNullOrEmpty(str))
            {
                StringBuilder sb = new StringBuilder();
                bool done = false;
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    if (!done && (i < str.Length - 1) && Char.IsLower(str[i + 1]))
                    {
                        done = true;
                    }
                    if (!done || (i == 0))
                    {
                        c = Char.ToLower(c);
                    }
                    sb.Append(c);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        public static string ToBackField(string str)
        {
            return "_" + ToCamelCase(str);
        }

        public static string ToPlural(string str)
        {
            string ret = str;
            if (!String.IsNullOrEmpty(str))
            {
                char c = str[str.Length - 1];
                switch (c)
                {
                    case 'y':
                        ret = str.Remove(str.Length - 1) + "ies";
                        break;
                    default:
                        ret = str + "s";
                        break;
                }
            }
            return ret;
        }

        private static bool AssertNull(object o)
        {
            bool ret = (o == null);
            if (!ret)
            {
                if (o is string)
                {
                    ret = String.IsNullOrEmpty((string)o);
                }
                if (o is XPathNodeIterator)
                {
                    ret = (((XPathNodeIterator)o).Count <= 0);
                }
            }
            return ret;
        }

        public static object ValueOrDefault(object v, object d)
        {
            object ret = v;
            if (AssertNull(v))
            {
                ret = d;
            }
            return ret;
        }

        public static string FormatString(string format, string arg1)
        {
            return String.Format(format, arg1);
        }
        public static string FormatString(string format, string arg1, string arg2)
        {
            return String.Format(format, arg1, arg2);
        }
        public static string FormatString(string format, string arg1, string arg2, string arg3)
        {
            return String.Format(format, arg1, arg2, arg3);
        }

        public static bool IsPrimitiveValueType(string typeName)
        {
            bool ret = true;
            switch (typeName)
            {
                case "string":
                    ret = false;
                    break;
            }
            return ret;
        }

        public static string MakeNullableType(string typeName)
        {
            string ret = typeName;
            if (IsPrimitiveValueType(typeName))
            {
                ret += "?";
            }
            return ret;
        }

        public static bool GetBooleanValue(object o, bool defaultValue)
        {
            bool ret = defaultValue;
            if (o is bool)
            {
                ret = (bool)o;
            }
            else if (o is XPathNodeIterator)
            {
                XPathNodeIterator xpni = (XPathNodeIterator)o;
                if (xpni.Count > 0)
                {
                    xpni.MoveNext();
                    XPathNavigator xpn = xpni.Current;
                    string str = xpn.Value;
                    ret = (String.Equals(str, "true") || String.Equals(str, "1"));
                }
            }
            return ret;
        }


        public static string FormatXslStringOutput(string str)
        {
            return (str == null ? String.Empty : str);
        }

        public static string StringValueOrDefaultPattern(string v, string defaultPattern, params object[] args)
        {
            string ret = v;
            if (String.IsNullOrEmpty(ret) && !String.IsNullOrEmpty(defaultPattern))
            {
                ret = String.Format(defaultPattern, args);
            }

            return FormatXslStringOutput(ret);
        }
    }
}
