using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wang.Velika.FamilyAccounting.Common.Logging
{
    public interface ILogProvider
    {
        void Log(string entryName, string messages);
    }
}
