using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    public interface IHistorySupport
    {
        HistoryCacheBag HistoryCache { get; }
    }
}
