using System;
using System.Collections.Generic;
using System.Text;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public enum ExtendedConfigurationElementOverrideMode : byte
    {
        Inherit = 0,
        OverrideFromAll = 1,
        OverrideFromNotEmpty = 2,
        Ignore = 5
    }
}
