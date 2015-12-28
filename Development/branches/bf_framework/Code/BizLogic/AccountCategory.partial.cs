using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.FamilyAccounting.BizLogic
{
    public partial class AccountCategory
    {
        partial void OnDefaultDirectionChanging(AccountingDirection? value);
        partial void OnDefaultDirectionChanged();
        public AccountingDirection? DefaultDirection
        {
            get
            {
                return (AccountingDirection)this.DefaultDirectionRaw;
            }
            set
            {
                this.OnDefaultDirectionChanging(value);
                this.DefaultDirectionRaw = (byte?)value;
                this.OnDefaultDirectionChanged();
            }
        }
    }

}
