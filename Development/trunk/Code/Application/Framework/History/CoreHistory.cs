using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    partial class CoreHistory
    {
        partial void OnActionTypeChanging(HistoryActionType value);
        partial void OnActionTypeChanged();
        public HistoryActionType ActionType
        {
            get
            {
                return (HistoryActionType)this.ActionTypeRaw;
            }
            set
            {
                this.OnActionTypeChanging(value);
                this.ActionTypeRaw = (byte)value;
                this.OnActionTypeChanged();
            }
        }

    }
}
