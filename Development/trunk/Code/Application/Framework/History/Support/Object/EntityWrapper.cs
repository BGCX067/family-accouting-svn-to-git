using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects.DataClasses;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    internal class EntityWrapper
    {
        public EntityState State { get; private set; }

        public EntityKey Key { get; private set; }

        public EntityObject Entity { get; private set; }


        public EntityWrapper(EntityState state, EntityKey key, EntityObject entity)
        {
            this.State = state;
            this.Key = key;
            this.Entity = entity;
        }
    }
}
