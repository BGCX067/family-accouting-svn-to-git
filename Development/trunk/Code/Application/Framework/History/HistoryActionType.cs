using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    public enum HistoryActionType : byte
    {
        Create = 1,
        Modify = 2,
        Delete = 3
    }
}
