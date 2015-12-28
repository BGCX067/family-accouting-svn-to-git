using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata
{
    public static class MetadataManager
    {
        public static EntityTypeInfo GetEntityType(int id)
        {
            EntityTypeInfo ret = null;
            using (EntityMetadataContext ctx = EntityMetadataContext.CreateInstance())
            {
                ret = ctx.GetEntityType(id);
            }

            return ret;
        }

        public static EntityPropertyInfo GetEntityProperty(int id, bool throwIfNull)
        {
            EntityPropertyInfo ret = null;
            using (EntityMetadataContext ctx = EntityMetadataContext.CreateInstance())
            {
                ret = ctx.GetEntityProperty(id);
            }
            if ((ret == null) && throwIfNull)
            {
                //TODO: throw
            }

            return ret;
        }
    }
}
