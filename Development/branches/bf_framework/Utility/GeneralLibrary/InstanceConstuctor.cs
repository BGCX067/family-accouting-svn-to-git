using System;
using System.Collections.Generic;
using System.Text;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public delegate TInstance InstanceConstuctor<TInstance>()
        where TInstance : class;
}
