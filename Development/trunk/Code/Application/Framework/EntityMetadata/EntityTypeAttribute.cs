using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityTypeAttribute : Attribute
    {
        public int EntityTypeID { get; private set; }

        public EntityTypeAttribute(int entityTypeID)
        {
            this.EntityTypeID = entityTypeID;
        }


        public static EntityTypeAttribute RetrieveEntityType(Type t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }

            return (EntityTypeAttribute)Attribute.GetCustomAttribute(t, typeof(EntityTypeAttribute));
        }
    }
}
