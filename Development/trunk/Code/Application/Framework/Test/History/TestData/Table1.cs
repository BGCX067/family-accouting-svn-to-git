using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.History;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;
using System.Data.Objects.DataClasses;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.History
{
    [EntityType(1)]
    partial class Table1 : IWithHistory<Table1History>, IWithHistory
    {
        public virtual IList<IHistory> CreateHistoryEntities(CoreHistory coreHistory)
        {
            return new IHistory[] { ((IWithHistory<Table1History>)this).CreateHistoryEntity(coreHistory) };
        }


        #region IEntityExtend Members

        int IEntityExtend.EntityTypeID
        {
            get
            {
                return 1;
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

        #region IWithHistory<Table1History> Members

        Table1History IWithHistory<Table1History>.CreateHistoryEntity(CoreHistory coreHistory)
        {
            Table1History ret = new Table1History();
            ret.ID = coreHistory.ID;
            ret.Table1ID = this.ID;
            ret.PropertyInt = this.PropertyInt;
            ret.PropertyString = this.PropertyString;
            ret.PropertyDatetime = this.PropertyDatetime;

            return ret;
        }

        #endregion


        public EntityCollection<Table4> DualTable4s
        {
            get
            {
                return this.DecorateEntityCollection(104, this.DualTable4sRaw);
            }
        }
    }
}
