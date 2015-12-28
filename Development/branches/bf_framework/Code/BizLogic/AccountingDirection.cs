using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.FamilyAccounting.BizLogic
{
    public enum AccountingDirection : byte
    {
        /// <summary>
        /// 借方 Debit
        /// </summary>
        Debit = 1,

        /// <summary>
        /// 贷方 Credit
        /// </summary>
        Credit = 2
    }
}
