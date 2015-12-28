using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.History;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.History
{
    [EntityType(2)]
    partial class Table2 : IWithHistory<Table2History>, IWithHistory
    {
        public virtual IList<IHistory> CreateHistoryEntities(CoreHistory coreHistory)
        {
            return new IHistory[] { ((IWithHistory<Table2History>)this).CreateHistoryEntity(coreHistory) };
        }


        #region IEntityExtend Members

        int IEntityExtend.EntityTypeID
        {
            get
            {
                return 2;
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

        #region IWithHistory<Table2History> Members

        Table2History IWithHistory<Table2History>.CreateHistoryEntity(CoreHistory coreHistory)
        {
            Table2History ret = new Table2History();
            ret.ID = coreHistory.ID;
            ret.Table2ID = this.ID;
            ret.PropertyString = this.PropertyString;

            return ret;
        }

        #endregion
    }
}
