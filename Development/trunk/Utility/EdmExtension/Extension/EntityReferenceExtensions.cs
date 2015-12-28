using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Wang.Velika.Utility.EdmExtension
{
    public static class EntityReferenceExtensions
    {
        public static TEntity GetValueAutoLoaded<TEntity>(this EntityReference<TEntity> reference)
            where TEntity : class, IEntityWithRelationships
        {
            if (!reference.IsLoaded)
            {
                reference.Load();
            }

            return reference.Value;
        }
    }
}
