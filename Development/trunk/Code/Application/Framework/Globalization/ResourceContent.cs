using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;
using Wang.Velika.FamilyAccounting.Application.Framework.History;
using Wang.Velika.Utility.EdmExtension;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Globalization
{
    [EntityType(112)]
    partial class ResourceContent : IWithHistory<ResourceContentHistory>, IWithHistory
    {
        public virtual IList<IHistory> CreateHistoryEntities(CoreHistory coreHistory)
        {
            return new IHistory[] { ((IWithHistory<ResourceContentHistory>)this).CreateHistoryEntity(coreHistory) };
        }


        #region IEntityExtend Members

        int IEntityExtend.EntityTypeID
        {
            get
            {
                return 112;
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

        #region IWithHistory<ResourceContent> Members

        ResourceContentHistory IWithHistory<ResourceContentHistory>.CreateHistoryEntity(CoreHistory coreHistory)
        {
            ResourceContentHistory ret = new ResourceContentHistory();
            ret.ID = coreHistory.ID;
            ret.ResourceContentID = this.ID;
            ret.LanguageSetID = this.LanguageReference.GetValueAutoLoaded().ID;
            ret.ResourceKeyID = this.KeyReference.GetValueAutoLoaded().ID;
            ret.Content = this.Content;

            return ret;
        }

        #endregion
    }
}
