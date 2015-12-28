using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wang.Velika.FamilyAccounting.Common.Logging
{
    public static class LogManager
    {
        private static ILogProvider logger;


        static LogManager()
        {
            logger = new EnterpriseLibraryLogProvider();
        }


        public static void Log(string entryname,string message)
        {
            logger.Log(entryname, message);
        }

        public static void LogWithFormat(string entryName, string format, params object[] args)
        {
            string message = format;
            if (message != null)
            {
                message = String.Format(message, args);
            }

            Log(entryName, message);
        }
    }
}
