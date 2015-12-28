using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public class EntitySQLGroupItem : EntitySQLFieldRelationItemBase
    {
        private const string ENTITY_SQL_SEGMENT_PATTERN_AGGREGATION = "{0} AS {1}";


        public override bool Enabled
        {
            get
            {
                return true;
            }
        }


        public EntitySQLGroupItem(string fieldName)
            : this(fieldName, null)
        {
        }

        public EntitySQLGroupItem(string fieldName, string aggregationPattern)
            : base(fieldName, aggregationPattern)
        {
        }


        protected override string BuildEntitySQLSegmentFromFieldNameSegment(string fieldNameSegment, bool useAggregation)
        {
            string ret = fieldNameSegment;
            if (useAggregation && this.HasAggrgation)
            {
                ret = String.Format(ENTITY_SQL_SEGMENT_PATTERN_AGGREGATION, ret, this.FieldName);
            }

            return ret;
        }
    }
}
