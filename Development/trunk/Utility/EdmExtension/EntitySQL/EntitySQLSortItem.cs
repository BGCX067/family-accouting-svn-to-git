using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public class EntitySQLSortItem : EntitySQLFieldRelationItemBase
    {
        private const string ENTITY_SQL_SEGMENT_PATTERN = "{0} {1}";


        public EntitySQLSortDirection Direction { get; set; }

        public override bool Enabled
        {
            get
            {
                return true;
            }
        }


        public EntitySQLSortItem(string fieldName, EntitySQLSortDirection direction)
            : this(fieldName, null, direction)
        {
        }

        public EntitySQLSortItem(string fieldName, string aggregationPattern, EntitySQLSortDirection direction)
            : base(fieldName, aggregationPattern)
        {
            if (direction == null)
            {
                throw new ArgumentNullException("direction");
            }

            this.Direction = direction;
        }


        protected override string BuildEntitySQLSegmentFromFieldNameSegment(string fieldNameSegment, bool useAggregation)
        {
            return String.Format(ENTITY_SQL_SEGMENT_PATTERN, fieldNameSegment, this.Direction.SQLSegment);
        }

        protected override string BuildFieldNameSegment(string entityAlias, bool useAggregation)
        {
            string ret = null;
            if (useAggregation)
            {
                ret = this.FieldName;
            }
            else
            {
                ret = base.BuildFieldNameSegment(entityAlias, useAggregation);
            }

            return ret;
        }
    }
}
