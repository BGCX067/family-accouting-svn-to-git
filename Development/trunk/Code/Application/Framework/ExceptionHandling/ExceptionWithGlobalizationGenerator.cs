using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using Wang.Velika.FamilyAccounting.Common.Logging;


namespace Wang.Velika.FamilyAccounting.Application.Framework.ExceptionHandling
{
    public static class ExceptionWithGlobalizationGenerator
    {
        public const string LOGGING_ENTRY = "ExceptionHandling";


        public static string ParseResourceString<TException>(string resourceKey, params object[] args)
            where TException : Exception
        {
            string ret = null;
            if (resourceKey == null)
            {
                LogManager.LogWithFormat(LOGGING_ENTRY, "Creating an exception (type of {0}) with NULL resource key. Passed NULL value back as Exception.Message", typeof(TException));
            }
            else
            {
                ret = InformationCenter.States.LanguageInfo.ResourceProvider.GetString(resourceKey, null, args);
            }

            return ret;
        }

        public static ArgumentNullException CreateArgumentNullException(string parameterName)
        {
            return new ArgumentNullException(parameterName, ParseResourceString<ArgumentNullException>("Application.Exception.General.ArgumentNull", parameterName));
        }

        public static ArgumentNullException CreateArgumentNullException(string parameterName, Exception innerException)
        {
            return new ArgumentNullException(ParseResourceString<ArgumentNullException>("Application.Exception.General.ArgumentNull", parameterName), innerException);
        }
    }
}
