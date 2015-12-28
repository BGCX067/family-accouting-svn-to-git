using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public class PagingInfo
    {
        private int _startIndex;
        public int StartIndex
        {
            get { return _startIndex; }
            set { _startIndex = value; }
        }

        private int? _count;
        public int? Count
        {
            get { return _count; }
            set { _count = value; }
        }
    }
}
