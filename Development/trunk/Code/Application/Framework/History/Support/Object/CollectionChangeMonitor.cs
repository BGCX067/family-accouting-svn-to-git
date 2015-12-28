using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.ComponentModel;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    internal class CollectionChangeMonitor<TEntity, TProperty> : ChangeMonitorBase
        where TEntity : EntityObject, IWithHistory
        where TProperty : EntityObject, IEntityExtend
    {
        public new TEntity Entity
        {
            get
            {
                return (TEntity)base.Entity;
            }
        }

        public EntityCollection<TProperty> Collection
        {
            get
            {
                return (EntityCollection<TProperty>)base.TargetEnd;
            }
        }


        public CollectionChangeMonitor(TEntity entity, int propertyID, EntityCollection<TProperty> collection)
            : base(entity, propertyID, collection)
        {
        }


        protected override void CollectionAssociationChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action != CollectionChangeAction.Refresh)
            {
                lock (this.Entity.CollectionChanges.ChangedEntries)
                {
                    ChangeActionKind action = (e.Action == CollectionChangeAction.Add ? ChangeActionKind.AddItem : ChangeActionKind.RemoveItem);

                    ChangeEntry entry = this.Entity.CollectionChanges.ChangedEntries.Find(x =>
                        (x.Monitor.PropertyID == this.PropertyID)
                        && (x.Action != action)
                        && this.AssertEntityEqual(x.Target, (TProperty)e.Element));
                    if (entry == null)
                    {
                        this.Entity.CollectionChanges.ChangedEntries.Add(new ChangeEntry(this, this.Entity, (TProperty)e.Element, action));
                    }
                    else
                    {
                        this.Entity.CollectionChanges.ChangedEntries.Remove(entry);
                    }
                }
            }
        }
    }
}
