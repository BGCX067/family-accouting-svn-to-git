using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wang.Velika.FamilyAccounting.Application.Framework.Core
{
    public interface ITransactionProvider : IDisposable
    {
        void ReadyToCommit();
    }
}
