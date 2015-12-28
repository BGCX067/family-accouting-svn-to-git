using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata
{
    public enum EntityPropertyTargetKind : byte
    {
        NormalScalar = 1,
        Enumeration = 2,
        SingleRelated = 3,
        List = 4
    }
}
