using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.History;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;
using System.Data.Objects.DataClasses;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.History
{
    [EntityType(4)]
    partial class Table4 : IWithHistory<Table4History>, IWithHistory
    {
        public virtual IList<IHistory> CreateHistoryEntities(CoreHistory coreHistory)
        {
            return new IHistory[] { ((IWithHistory<Table4History>)this).CreateHistoryEntity(coreHistory) };
        }


        #region IEntityExtend Members

        int IEntityExtend.EntityTypeID
        {
            get
            {
                return 4;
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

        #region IWithHistory<Table4History> Members

        Table4History IWithHistory<Table4History>.CreateHistoryEntity(CoreHistory coreHistory)
        {
            Table4History ret = new Table4History();
            ret.ID = coreHistory.ID;
            ret.Table4ID = this.ID;
            ret.PropertyString = this.PropertyString;
            if (this.DualTable1 != null)
            {
                ret.Table1ID = this.DualTable1.ID;
            }
            if (this.MonoTable2 != null)
            {
                ret.Table2ID = this.MonoTable2.ID;
            }
            if (this.MetaTable3 != null)
            {
                ret.Table3ID = this.MetaTable3.ID;
            }

            return ret;
        }

        #endregion


        public EntityReference<Table1> DualTable1Reference
        {
            get
            {
                return this.DecorateEntityReference(402, this.DualTable1RawReference);
            }
        }

        public Table1 DualTable1
        {
            get
            {
                return this.DualTable1Reference.Value;
            }
            set
            {
                this.DualTable1Reference.Value = value;
            }
        }

        public EntityReference<Table2> MonoTable2Reference
        {
            get
            {
                return this.DecorateEntityReference(403, this.MonoTable2RawReference);
            }
        }

        public Table2 MonoTable2
        {
            get
            {
                return this.MonoTable2Reference.Value;
            }
            set
            {
                this.MonoTable2Reference.Value = value;
            }
        }

        public EntityReference<Table3> MetaTable3Reference
        {
            get
            {
                return this.DecorateEntityReference(404, this.MetaTable3RawReference);
            }
        }

        public Table3 MetaTable3
        {
            get
            {
                return this.MetaTable3Reference.Value;
            }
            set
            {
                this.MetaTable3Reference.Value = value;
            }
        }

        public EntityCollection<Table5> DualTable5s
        {
            get
            {
                return this.DecorateEntityCollection(405, this.DualTable5sRaw);
            }
        }

        public EntityCollection<Table5> MonoTable5s
        {
            get
            {
                return this.DecorateEntityCollection(406, this.MonoTable5sRaw);
            }
        }
    }
}
