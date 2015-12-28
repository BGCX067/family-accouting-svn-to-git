using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.History;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.History
{
    partial class Table2History : IHistory
    {
        #region IHistory Members

        string IHistory.EntitySetName
        {
            get
            {
                return "Table2HistorySet";
            }
        }

        #endregion
    }
}
