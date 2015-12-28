using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public class EntitySQLFilterItem : EntitySQLFieldRelationItemBase
    {
        private const string ENTITY_SQL_SEGMENT_PATTERN = "({0} {1} {2})";


        public EntitySQLFilterOperation Operation { get; set; }

        public object RelativeValue { get; set; }

        public bool? ExplicitlyEnabled { get; set; }

        public bool NullAsDisabled { get; set; }

        public override bool Enabled
        {
            get
            {
                bool ret = false;
                if (this.ExplicitlyEnabled.HasValue)
                {
                    ret = this.ExplicitlyEnabled.Value;
                }
                else if (this.NullAsDisabled)
                {
                    ret = (this.RelativeValue != null);
                }

                return ret;
            }
        }


        public EntitySQLFilterItem(string fieldName, EntitySQLFilterOperation operation, object relativeValue)
            : this(fieldName, operation, relativeValue, null)
        {
        }

        public EntitySQLFilterItem(string fieldName, EntitySQLFilterOperation operation, object relativeValue, Func<string, string, bool, string> customSQLSegmentBuilder)
            : base(fieldName, customSQLSegmentBuilder)
        {
            //TODO: To handle "operation == null".
            this.NullAsDisabled = true;

            this.Operation = operation;
            this.RelativeValue = relativeValue;
        }


        protected override string BuildEntitySQLSegmentFromFieldNameSegment(string fieldNameSegment, bool useAggregation)
        {
            string ret = null;
            string opreatorSegment = this.Operation.SQLSegment;
            string relativeValueSegment = EdmHelper.EncodeValueForStatement(this.RelativeValue, this.Operation.SpecialRelativeValueFormat);
            ret = String.Format(ENTITY_SQL_SEGMENT_PATTERN, fieldNameSegment, opreatorSegment, relativeValueSegment);

            return ret;
        }
    }
}
