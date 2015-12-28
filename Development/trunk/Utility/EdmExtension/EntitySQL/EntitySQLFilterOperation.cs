using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public sealed class EntitySQLFilterOperation : EntitySQLNamedSegmentBase
    {
        private EntitySQLFilterOperation(string name, string sqlSegment)
            : base(name, sqlSegment)
        {
        }

        private EntitySQLFilterOperation(string name, string sqlSegment, string specialRelativeValueFormat)
            : base(name, sqlSegment, specialRelativeValueFormat)
        {
        }


        public static readonly EntitySQLFilterOperation EqualsTo = new EntitySQLFilterOperation("EqualsTo", "=");

        public static readonly EntitySQLFilterOperation NotEqualsTo = new EntitySQLFilterOperation("NotEqualsTo", "<>");

        public static readonly EntitySQLFilterOperation LessThan = new EntitySQLFilterOperation("LessThan", "<");

        public static readonly EntitySQLFilterOperation LessThanOrEqual = new EntitySQLFilterOperation("LessThanOrEqual", "<=");

        public static readonly EntitySQLFilterOperation GreaterThan = new EntitySQLFilterOperation("GreaterThan", ">");

        public static readonly EntitySQLFilterOperation GreaterThanOrEauql = new EntitySQLFilterOperation("GreaterThanOrEauql", ">=");

        public static readonly EntitySQLFilterOperation Like = new EntitySQLFilterOperation("Like", "LIKE");

        public static readonly EntitySQLFilterOperation NotLike = new EntitySQLFilterOperation("Like", "NOT LIKE");

        public static readonly EntitySQLFilterOperation In = new EntitySQLFilterOperation("In", "IN", "({0})");
    }
}
