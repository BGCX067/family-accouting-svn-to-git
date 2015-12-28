using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public sealed class EntitySQLSortDirection : EntitySQLNamedSegmentBase
    {
        private EntitySQLSortDirection(string name, string sqlSegment)
            : base(name, sqlSegment)
        {
        }


        public static readonly EntitySQLSortDirection Ascending = new EntitySQLSortDirection("Ascending", "ASC");

        public static readonly EntitySQLSortDirection Descending = new EntitySQLSortDirection("Descending", "DESC");
    }
}
