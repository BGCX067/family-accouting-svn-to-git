using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EntityPropertyAttribute : Attribute
    {
        public int EntityPropertyID { get; private set; }

        public EntityPropertyAttribute(int entityPropertyID)
        {
            this.EntityPropertyID = entityPropertyID;
        }


        public static EntityPropertyAttribute RetrieveEntityType(Type t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }

            return (EntityPropertyAttribute)Attribute.GetCustomAttribute(t, typeof(EntityPropertyAttribute));
        }
    }
}
