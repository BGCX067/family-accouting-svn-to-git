using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using Wang.Velika.Utility.EdmExtension;

namespace Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata
{
    [ObjectContextMetadataMapping("DataModel")]
    partial class EntityMetadataContext
    {
        public static EntityMetadataContext CreateInstance()
        {
            return InformationCenter.States.DBInfo.RetrieveContext<EntityMetadataContext>();
        }


        protected override void Dispose(bool disposing)
        {
            this.DetachAllObjects();

            base.Dispose(disposing);
        }


        public EntityTypeInfo GetEntityType(int id)
        {
            var ret = from et in this.EntityTypeInfoSet
                      where et.ID == id
                      select et;

            return ret.FirstOrDefault();
        }

        public EntityPropertyInfo GetEntityProperty(int id)
        {
            var ret = from et in this.EntityPropertyInfoSet
                      where et.ID == id
                      select et;

            return ret.FirstOrDefault();
        }
    }
}
