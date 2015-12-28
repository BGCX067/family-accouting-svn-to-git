using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;


namespace Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata
{
    public static class EntityExtendExtensions
    {
        public static EntityTypeInfo GetEntityInfo<T>(this T entity)
            where T : EntityObject, IEntityExtend
        {
            return MetadataManager.GetEntityType(entity.EntityTypeID);
        }
    }
}
