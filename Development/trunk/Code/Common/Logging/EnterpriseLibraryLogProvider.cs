using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;


namespace Wang.Velika.FamilyAccounting.Common.Logging
{
    internal class EnterpriseLibraryLogProvider : ILogProvider
    {
        #region ILogmanager Members

        public void Log(string entryName, string messages)
        {
            LogEntry logEntry = new LogEntry();
            logEntry.Categories.Add(entryName);
            logEntry.Message = messages;
            Logger.Write(logEntry);
        }

        #endregion
    }
}
