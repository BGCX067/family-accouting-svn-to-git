using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Reflection;
using System.Data;
using System.Data.Metadata.Edm;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    internal class RelationWrapper
    {
        public AssociationSet Definition { get; private set; }

        public EntityKey Key0 { get; private set; }

        public EntityKey Key1 { get; private set; }

        public EntityState State { get; private set; }


        public RelationWrapper(ObjectStateEntry relation)
        {
            if (relation == null)
            {
                throw new ArgumentNullException("relation");
            }
            if (!relation.IsRelationship)
            {
                //TODO: throw;
            }

            this.ProcessRelationEntry(relation);
        }


        private void ProcessRelationEntry(ObjectStateEntry relation)
        {
            this.Definition = (AssociationSet)relation.EntitySet;
            Type tRelation = typeof(ObjectStateEntry).Assembly.GetType("System.Data.Objects.RelationshipEntry");
            PropertyInfo pKey0 = tRelation.GetProperty("Key0", BindingFlags.Instance | BindingFlags.NonPublic);
            PropertyInfo pKey1 = tRelation.GetProperty("Key1", BindingFlags.Instance | BindingFlags.NonPublic);
            this.Key0 = (EntityKey)pKey0.GetValue(relation, null);
            this.Key1 = (EntityKey)pKey1.GetValue(relation, null);
            this.State = relation.State;
        }

        internal IList<RelationEndWrapper> GetRelationEnds()
        {
            List<RelationEndWrapper> ret = new List<RelationEndWrapper>();
            ret.Add(new RelationEndWrapper(this.Key0, this.Definition.ElementType.AssociationEndMembers[0], this.Key1, this.Definition.ElementType.AssociationEndMembers[1]));
            ret.Add(new RelationEndWrapper(this.Key1, this.Definition.ElementType.AssociationEndMembers[1], this.Key0, this.Definition.ElementType.AssociationEndMembers[0]));

            return ret;
        }
    }
}
