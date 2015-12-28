using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.History;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.History
{
    [EntityType(503)]
    partial class Table3 : IEntityExtend
    {
        #region IEntityExtend Members

        int IEntityExtend.EntityTypeID
        {
            get
            {
                return 503;
            }
        }

        int IEntityExtend.EntityID
        {
            get
            {
                return this.ID;
            }
        }

        #endregion
    }
}
