using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public abstract class SearchCriteriaBase
    {
        protected SearchCriteriaBase()
        {
        }


        internal protected virtual void FillQueryFilters(List<EntitySQLFilterItem> filters, EntitySQLQueryWrapper wrapper)
        {
        }
    }
}
