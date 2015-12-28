using System;
using System.Collections.Generic;
using System.Text;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public static class ExceptionHelper
    {
        private const string EXCEPTION_STRING_FORMAT = @"{0}Exception of type {{{1}}} with message ""{2}"" occured at:
{0}{3}";
        private const string EXCEPTION_STRING_FORMAT_INNER = @"{0}There is inner exception {1} with message ""{2}"" at:
{0}{3}";
        private const string EXCEPTION_STRING_FORMAT_PADDING_UNIT = "\t";


        public static string ConvertToString(Exception ex)
        {
            string ret = null;
            string padding = String.Empty;
            while (ex != null)
            {
                ret = String.Format((String.IsNullOrEmpty(padding)?EXCEPTION_STRING_FORMAT:EXCEPTION_STRING_FORMAT_INNER),
                    padding,
                    ex.GetType(),
                    ex.Message,
                    ex.StackTrace);
                ex = ex.InnerException;
                padding += EXCEPTION_STRING_FORMAT_PADDING_UNIT;
            }

            return ret;
        }
    }
}
