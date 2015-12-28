using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.Utility.EdmExtension;

namespace Wang.Velika.FamilyAccounting.BizLogic
{
    [ObjectContextMetadataMapping("Model")]
    public partial class EntitiesContext
    {
        public static EntitiesContext CreateInstance()
        {
            return EnvironmentHolder.ContextAssistant.CreateEntityContext<EntitiesContext>(EnvironmentHolder.Connection, null);
        }
    }
}
