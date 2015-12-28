using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public interface ISearchDataWrapper
    {
        SearchCriteriaBase SearchCriteria { get; }

        SortSequenceBase SortSequence { get; }

        PagingInfo Paging { get; }
    }
}
