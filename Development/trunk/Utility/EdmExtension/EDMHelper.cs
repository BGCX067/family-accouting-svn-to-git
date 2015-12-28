using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using Wang.Velika.Utility.GeneralLibrary;

namespace Wang.Velika.Utility.EdmExtension
{
    public static class EdmHelper
    {
        public static string EncodeValueForStatement(object v, string extraFormat)
        {
            string ret = null;
            if (v != null)
            {
                if (v is ObjectQuery)
                {
                    ret = ((ObjectQuery)v).CommandText;
                }
                //TODO: Need to handle DateTime.
                else
                {
                    ret = SQLHelper.EncodeValueForStatement(v);
                }
            }
            if (extraFormat != null)
            {
                ret = String.Format(extraFormat, ret);
            }

            return ret;
        }
    }
}
