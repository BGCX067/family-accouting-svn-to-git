using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    public interface IWithHistory : IEntityExtend
    {
        IList<IHistory> CreateHistoryEntities(CoreHistory coreHistory);

        CollectionChangeHolder CollectionChanges { get; }
    }


    public interface IWithHistory<THistory>
        where THistory : EntityObject, IHistory
    {
        THistory CreateHistoryEntity(CoreHistory coreHistory);
    }
}
