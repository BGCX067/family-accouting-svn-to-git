using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Metadata.Edm;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    /// <summary>
    /// Each object of this type represents an effective positively change action from consumer.
    /// </summary>
    internal class RelationEndWrapper
    {
        public EntityKey SourceKey { get; private set; }

        public AssociationEndMember SourceAssociationEnd { get; private set; }

        public EntityKey TargetKey { get; private set; }

        public AssociationEndMember TargetAssociationEnd { get; private set; }


        public RelationEndWrapper(EntityKey sourceKey, AssociationEndMember sourceAssociationEnd, EntityKey targetKey, AssociationEndMember targetAssociationEnd)
        {
            this.SourceKey = sourceKey;
            this.SourceAssociationEnd = sourceAssociationEnd;
            this.TargetKey = targetKey;
            this.TargetAssociationEnd = targetAssociationEnd;
        }
    }
}
