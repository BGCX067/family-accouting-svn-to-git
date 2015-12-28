using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.History;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Globalization
{
    partial class ResourceContentHistory : IHistory
    {
        #region IHistory Members

        string IHistory.EntitySetName
        {
            get
            {
                return "ResourceContentHistorySet";
            }
        }

        #endregion
    }
}
