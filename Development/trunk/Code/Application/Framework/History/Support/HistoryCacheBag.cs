using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;
using System.Data.Objects.DataClasses;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;
using System.Data.Metadata.Edm;
using System.ComponentModel;
using Wang.Velika.Utility.EdmExtension;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    public class HistoryCacheBag
    {
        private List<EntityWrapper> _entities;
        private List<EntityWrapper> Entities
        {
            get
            {
                if (this._entities == null)
                {
                    this._entities = new List<EntityWrapper>();
                }
                return this._entities;
            }
        }

        private List<RelationWrapper> _relations;
        private List<RelationWrapper> Relations
        {
            get
            {
                if (this._relations == null)
                {
                    this._relations = new List<RelationWrapper>();
                }
                return this._relations;
            }
        }

        internal void AddChangedEntity(EntityState state, EntityObject entity)
        {
            this.Entities.Add(new EntityWrapper(state, entity.EntityKey, entity));
        }

        internal void AddChangedRelation(ObjectStateEntry relation)
        {
            this.Relations.Add(new RelationWrapper(relation));
        }

        internal void Clear()
        {
            this._entities = null;
            this._relations = null;
            this.historyEntities = null;
        }

        internal void AddHistories(ObjectContext ctx)
        {
            this.InferRelationHistories(ctx);
            this.AddEntityHistories(ctx, EntityState.Deleted, HistoryActionType.Delete);
            this.AddEntityHistories(ctx, EntityState.Modified, HistoryActionType.Modify);
            this.AddEntityHistories(ctx, EntityState.Added, HistoryActionType.Create);
        }

        private Dictionary<EntityKey, IList<IHistory>> historyEntities;

        private void InferRelationHistories(ObjectContext ctx)
        {
            List<RelationWrapper> relations = new List<RelationWrapper>(this.Relations);
            // The first time scan for those have corresponding change action recorded.
            for (int i = 0; i < relations.Count; i++)
            {
                RelationWrapper relation = relations[i];
                // Look into the relationship from two direction, which could provide a uniform way.
                foreach (RelationEndWrapper end in relation.GetRelationEnds())
                {
                    object entityRaw;
                    if (ctx.TryGetObjectByKey(end.SourceKey, out entityRaw))
                    {
                        IWithHistory entity = entityRaw as IWithHistory;
                        if (entity != null)
                        {
                            ChangeEntry change = entity.CollectionChanges.ChangedEntries.Find(x => this.AssertChangeMatch(x, relation, end.TargetAssociationEnd.Name));
                            // Find out recorded change action matches current relation..
                            if (change != null)
                            {
                                // Remove from list. let the rest of list keep clean as not developed.
                                relations.Remove(relation);
                                i--;

                                HistoryPreparation hp = new HistoryPreparation(change);
                                // Prepare basic change history.
                                RawChangeHistory rch = new RawChangeHistory(change.Source,
                                    change.Monitor.PropertyID,
                                    change.Target,
                                    change.Action);
                                hp.Relations.Add(rch);

                                // Start prepare extra history.
                                if (end.TargetAssociationEnd.RelationshipMultiplicity == RelationshipMultiplicity.Many)
                                {
                                    // This is n to n association.
                                    if (change.Target is IWithHistory)
                                    {
                                        // Whether this EntityType at opposite requires history and has corresponding property in metadata.
                                        EntityPropertyInfo pi = MetadataManager.GetEntityProperty(change.Monitor.PropertyID, true);
                                        if (pi.OppositePropertyReference.GetValueAutoLoaded() != null)
                                        {
                                            RawChangeHistory rch1 = new RawChangeHistory(change.Target,
                                                pi.OppositePropertyReference.GetValueAutoLoaded().ID,
                                                change.Source,
                                                change.Action);
                                            hp.Relations.Add(rch1);
                                        }
                                    }
                                }
                                else
                                {
                                    // This is n to 0..1 association.
                                    if (change.Action == CollectionChangeAction.Add)
                                    {
                                        EntityPropertyInfo pi = MetadataManager.GetEntityProperty(change.Monitor.PropertyID, true);
                                        RelationEndWrapper end1 = null;
                                        // Find out a deleted relation which is possibly occur because of current added one.
                                        RelationWrapper relation1 = relations.Find(x =>
                                            (x.State == EntityState.Deleted)
                                            && String.Equals(x.Definition.Name, relation.Definition.Name)
                                            && this.AssertRelationSameTarget(x, relation, EntityState.Deleted, end, out end1));
                                        if (relation1 != null)
                                        {
                                            if (entity.CollectionChanges.ChangedEntries.Find(x => this.AssertChangeMatch(x, relation, end.TargetAssociationEnd.Name)) == null)
                                            {
                                                // No recorded change matches this relation. so it did really occur because of current added one.
                                                if (relations.IndexOf(relation1) <= i)
                                                {
                                                    i--;
                                                }
                                                relations.Remove(relation1);
                                                RawChangeHistory rch1 = new RawChangeHistory((EntityObject)ctx.GetObjectByKey(end1.SourceKey), change.Monitor.PropertyID, change.Target, CollectionChangeAction.Remove);
                                                hp.Relations.Add(rch1);
                                            }
                                        }
                                        if ((change.Target is IWithHistory)
                                            && (pi.OppositePropertyReference.GetValueAutoLoaded() != null))
                                        {
                                            hp.Entities.Add(change.Target);
                                        }
                                    }
                                }
                                entity.CollectionChanges.CachedHistories.Add(hp);
                            }
                        }
                    }
                }
            }
            // Second time scan for those relation changes launched by assigning on entity.
            for (int i = 0; i < relations.Count; i++)
            {
                RelationWrapper relation = relations[i];
                foreach (RelationEndWrapper end in relation.GetRelationEnds())
                {
                    if (end.TargetAssociationEnd.RelationshipMultiplicity != RelationshipMultiplicity.Many)
                    {
                        EntityWrapper er = this.Entities.Find(x => x.Key.Equals(end.SourceKey));
                        IWithHistory entity = null;
                        if (er == null)
                        {
                            // Normal properties of this entity have not been changed. so it should be added to entity history list.
                            entity = ctx.GetObjectByKey(end.SourceKey) as IWithHistory;
                            if (entity != null)
                            {
                                this.AddChangedEntity(EntityState.Unchanged, (EntityObject)entity);
                            }
                        }
                        else
                        {
                            entity = er.Entity as IWithHistory;
                        }
                        // Prepare relation histories.

                    }
                }
            }
        }

        private bool AssertRelationSameTarget(RelationWrapper relation, RelationWrapper targetRelation, EntityState state, RelationEndWrapper targetEnd, out RelationEndWrapper correspondingEnd)
        {
            correspondingEnd = null;
            bool ret = (relation.State == state)
                && String.Equals(relation.Definition.Name, targetRelation.Definition.Name);

            foreach (RelationEndWrapper end in relation.GetRelationEnds())
            {
                ret = String.Equals(end.TargetAssociationEnd.Name, correspondingEnd.TargetAssociationEnd.Name)
                    && end.TargetKey.Equals(targetEnd.TargetKey);
                if (ret)
                {
                    correspondingEnd = end;
                    break;
                }
            }

            return ret;
        }

        private bool AssertChangeMatch(ChangeEntry entry, RelationWrapper relation, string targetRoleName)
        {
            return String.Equals(entry.Monitor.TargetEnd.TargetRoleName, targetRoleName)
                && AssertCollectionChangeActionMatch(entry.Action, relation.State)
                && Object.Equals(entry.Monitor.TargetEnd.RelationshipSet, relation.Definition);
        }

        private bool AssertCollectionChangeActionMatch(CollectionChangeAction action, EntityState state)
        {
            return ((action == CollectionChangeAction.Add) && (state == EntityState.Added))
                || ((action == CollectionChangeAction.Remove) && (state == EntityState.Deleted));
        }

        private IList<IHistory> GetHistoryEntities(EntityKey key)
        {
            IList<IHistory> ret;
            if (this.historyEntities == null)
            {
                this.historyEntities = new Dictionary<EntityKey, IList<IHistory>>();
            }
            if (!this.historyEntities.TryGetValue(key, out ret))
            {
                ret = new List<IHistory>();
                this.historyEntities.Add(key, ret);
            }

            return ret;
        }

        private void AddEntityHistories(ObjectContext ctx, EntityState state, HistoryActionType action)
        {
            IEnumerable<EntityWrapper> entities = this.Entities.Where(x => x.State == state);
            foreach (EntityWrapper entityWrapper in entities)
            {
                if ((entityWrapper.Entity is EntityObject) && (entityWrapper.Entity is IEntityExtend))
                {
                    CoreHistory coreHistory = HistoryManager.CreateCoreHistory((IEntityExtend)entityWrapper.Entity, action, null, null);
                    if (entityWrapper.Entity is IWithHistory)
                    {
                        IList<IHistory> histories = ((IWithHistory)entityWrapper.Entity).CreateHistoryEntities(coreHistory);
                        foreach (IHistory history in histories)
                        {
                            this.GetHistoryEntities(entityWrapper.Key).Add(history);
                            ctx.AddObject(history.EntitySetName, history);
                        }
                    }
                }
            }
        }
    }
}
