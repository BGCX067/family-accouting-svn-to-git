using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public abstract class EntitySQLNamedSegmentBase
    {
        public string Name { get; private set; }

        public string SQLSegment { get; private set; }

        public string SpecialRelativeValueFormat { get; private set; }


        protected EntitySQLNamedSegmentBase(string name, string sqlSegment)
            : this(name, sqlSegment, null)
        {
        }

        protected EntitySQLNamedSegmentBase(string name, string sqlSegment, string specialRelativeValueFormat)
        {
            this.Name = name;
            this.SQLSegment = sqlSegment;
            this.SpecialRelativeValueFormat = specialRelativeValueFormat;
        }

    }
}
