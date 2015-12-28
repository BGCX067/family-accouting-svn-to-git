using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.ComponentModel;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    internal abstract class ChangeMonitorBase
    {
        public IWithHistory Entity { get; private set; }

        public int PropertyID { get; private set; }

        public RelatedEnd TargetEnd { get; private set; }


        public ChangeMonitorBase(IWithHistory entity, int propertyID, RelatedEnd collection)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            this.Entity = entity;
            this.PropertyID = propertyID;
            this.TargetEnd = collection;

            this.TargetEnd.AssociationChanged += new CollectionChangeEventHandler(this.CollectionAssociationChanged);
        }


        protected abstract void CollectionAssociationChanged(object sender, CollectionChangeEventArgs e);

        protected bool AssertEntityEqual(EntityObject obj1, EntityObject obj2)
        {
            bool ret = Object.ReferenceEquals(obj1, obj2);
            if (!ret)
            {
                ret = (obj1.EntityKey != null)
                    && (obj2.EntityKey != null)
                    && obj1.EntityKey.Equals(obj2.EntityKey);
            }

            return ret;
        }
    }
}
