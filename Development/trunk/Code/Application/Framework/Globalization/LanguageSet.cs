using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;
using Wang.Velika.FamilyAccounting.Application.Framework.History;
using System.Data.Objects.DataClasses;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Globalization
{
    [EntityType(111)]
    partial class LanguageSet : IWithHistory<LanguageSetHistory>, IWithHistory
    {
        public virtual IList<IHistory> CreateHistoryEntities(CoreHistory coreHistory)
        {
            return new IHistory[] { ((IWithHistory<LanguageSetHistory>)this).CreateHistoryEntity(coreHistory) };
        }


        #region IEntityExtend Members

        int IEntityExtend.EntityTypeID
        {
            get
            {
                return 111;
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

        #region IWithHistory<LanguageSetHistory> Members

        LanguageSetHistory IWithHistory<LanguageSetHistory>.CreateHistoryEntity(CoreHistory coreHistory)
        {
            LanguageSetHistory ret = new LanguageSetHistory();
            ret.ID = coreHistory.ID;
            ret.LanguageSetID = this.ID;
            ret.Name = this.Name;
            ret.CultureName = this.CultureName;

            return ret;
        }

        #endregion
    }
}
