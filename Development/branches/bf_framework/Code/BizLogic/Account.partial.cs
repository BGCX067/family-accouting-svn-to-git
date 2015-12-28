using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.FamilyAccounting.BizLogic
{
    public partial class Account
    {
        partial void OnCommonDirectionChanging(AccountingDirection? value);
        partial void OnCommonDirectionChanged();
        public AccountingDirection? CommonDirection
        {
            get
            {
                return (AccountingDirection?)this.CommonDirectionRaw;
            }
            set
            {
                this.OnCommonDirectionChanging(value);
                this.CommonDirectionRaw = (byte?)value;
                this.OnCommonDirectionChanged();
            }
        }

    }
}
