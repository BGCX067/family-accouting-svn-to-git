using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.ComponentModel;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    internal class RawChangeHistory
    {
        public EntityObject Source { get; private set; }

        public int PropertyID { get; private set; }

        public EntityObject Established { get; set; }

        public EntityObject Released { get; set; }


        public RawChangeHistory(EntityObject source, int propertyID)
        {
            this.Source = source;
            this.PropertyID = propertyID;
        }

        public RawChangeHistory(EntityObject source, int propertyID, EntityObject target, CollectionChangeAction action)
            : this(source, propertyID)
        {
            if (action == CollectionChangeAction.Add)
            {
                this.Established = target;
            }
            if (action == CollectionChangeAction.Remove)
            {
                this.Released = target;
            }
        }
    }
}
