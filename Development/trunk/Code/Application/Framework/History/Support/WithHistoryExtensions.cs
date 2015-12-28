using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    public static class WithHistoryExtensions
    {
        public static IList<CoreHistory> RetrieveCoreHistries<TEntity>(this TEntity entity)
            where TEntity : EntityObject, IWithHistory
        {
            IList<CoreHistory> ret = null;
            using (HistoryContext ctx = HistoryContext.CreateInstance())
            {
                ret = new List<CoreHistory>(ctx.FindHistories(entity.EntityTypeID, entity.EntityID));
            }

            return ret;
        }

        public static EntityCollection<TProperty> DecorateEntityCollection<TEntity, TProperty>(this TEntity entity, int propertyID, EntityCollection<TProperty> collection)
            where TEntity : EntityObject, IWithHistory
            where TProperty : EntityObject, IEntityExtend
        {
            if (entity.CollectionChanges == null)
            {
                // TODO: throw
            }

            ChangeMonitorBase monitor = entity.CollectionChanges.ChangeMonitors.Find(x => Object.ReferenceEquals(x.TargetEnd, collection));
            if (monitor == null)
            {
                monitor = new CollectionChangeMonitor<TEntity, TProperty>(entity, propertyID, collection);
                entity.CollectionChanges.ChangeMonitors.Add(monitor);
            }

            return collection;
        }

        public static EntityReference<TProperty> DecorateEntityReference<TEntity, TProperty>(this TEntity entity, int propertyID, EntityReference<TProperty> reference)
            where TEntity : EntityObject, IWithHistory
            where TProperty : EntityObject, IEntityExtend
        {
            if (entity.CollectionChanges == null)
            {
                // TODO: throw
            }

            ChangeMonitorBase monitor = entity.CollectionChanges.ChangeMonitors.Find(x => Object.ReferenceEquals(x.TargetEnd, reference));
            if (monitor == null)
            {
                monitor = new ReferenceChangeMonitor<TEntity, TProperty>(entity, propertyID, reference);
                entity.CollectionChanges.ChangeMonitors.Add(monitor);
            }

            return reference;
        }
    }
}
