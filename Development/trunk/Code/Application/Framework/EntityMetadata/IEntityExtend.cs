using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata
{
    public interface IEntityExtend
    {
        int EntityTypeID { get; }

        int EntityID { get; }
    }
}
