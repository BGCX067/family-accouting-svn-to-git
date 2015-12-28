using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.History;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;
using System.Data.Objects.DataClasses;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.History
{
    [EntityType(5)]
    partial class Table5 : IWithHistory<Table5History>, IWithHistory
    {
        public virtual IList<IHistory> CreateHistoryEntities(CoreHistory coreHistory)
        {
            return new IHistory[] { ((IWithHistory<Table5History>)this).CreateHistoryEntity(coreHistory) };
        }


        #region IEntityExtend Members

        int IEntityExtend.EntityTypeID
        {
            get
            {
                return 5;
            }
        }

        int IEntityExtend.EntityID
        {
            get
            {
                return this.ID;
            }
        }

        #endregion

        #region IWithHistory Members

        IList<IHistory> IWithHistory.CreateHistoryEntities(CoreHistory coreHistory)
        {
            return this.CreateHistoryEntities(coreHistory);
        }

        private CollectionChangeHolder _collectionChanges = new CollectionChangeHolder();
        CollectionChangeHolder IWithHistory.CollectionChanges
        {
            get
            {
                return this._collectionChanges;
            }
        }

        #endregion

        #region IWithHistory<Table5History> Members

        Table5History IWithHistory<Table5History>.CreateHistoryEntity(CoreHistory coreHistory)
        {
            Table5History ret = new Table5History();
            ret.ID = coreHistory.ID;
            ret.Table5ID = this.ID;
            ret.PropertyInt = this.PropertyInt;

            return ret;
        }

        #endregion


        public EntityCollection<Table4> DualTable4s
        {
            get
            {
                return this.DecorateEntityCollection(502, this.DualTable4sRaw);
            }
        }
    }
}
