using System;
using System.Collections.Generic;
using System.Text;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public static class SQLHelper
    {
        public static string EncodeValueForStatement(object v)
        {
            string ret = null;
            if (v != null)
            {
                if (v is string)
                {
                    ret = (string)v;
                    ret = ret.Replace("'", "''");
                    ret = String.Format("'{0}'", ret);
                }
                //TODO: Need to handle DateTime.
                else
                {
                    ret = v.ToString();
                }
            }

            return ret;
        }
    }
}
