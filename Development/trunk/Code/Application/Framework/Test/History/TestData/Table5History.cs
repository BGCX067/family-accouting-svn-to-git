﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.History;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.History
{
    partial class Table5History : IHistory
    {
        #region IHistory Members

        string IHistory.EntitySetName
        {
            get
            {
                return "Table5HistorySet";
            }
        }

        #endregion
    }
}
