using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata
{
    partial class EntityPropertyInfo
    {
        partial void OnTargetKindChanging(EntityPropertyTargetKind value);
        partial void OnTargetKindChanged();
        public EntityPropertyTargetKind TargetKind
        {
            get
            {
                return (EntityPropertyTargetKind)this.TargetKindRaw;
            }
            set
            {
                this.OnTargetKindChanging(value);
                this.TargetKindRaw = (byte)value;
                this.OnTargetKindChanged();
            }
        }

    }
}
