using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.ComponentModel;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    internal class ReferenceChangeMonitor<TEntity, TProperty> : ChangeMonitorBase
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

        public EntityReference<TProperty> Reference
        {
            get
            {
                return (EntityReference<TProperty>)base.TargetEnd;
            }
        }


        public ReferenceChangeMonitor(TEntity entity, int propertyID, EntityReference<TProperty> reference)
            : base(entity, propertyID, reference)
        {
        }


        protected override void CollectionAssociationChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action != CollectionChangeAction.Refresh)
            {
                ChangeEntry entry = this.Entity.CollectionChanges.ChangedEntries.Find(x =>
                    (x.Monitor.PropertyID == this.PropertyID)
                    && (x.Action == ChangeActionKind.Assign));
                if (entry == null)
                {
                    this.Entity.CollectionChanges.ChangedEntries.Add(new ChangeEntry(this, this.Entity, null, ChangeActionKind.Assign));
                }
            }
        }
    }
}
