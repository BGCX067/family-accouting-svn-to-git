using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public abstract class EntitySQLFieldRelationItemBase
    {
        private const string FIELD_NAME_SEGMENT_PATTERN = "{0}.{1}";


        public virtual string FieldName { get; set; }

        public virtual string AggregationPattern { get; set; }

        public bool HasAggrgation
        {
            get
            {
                return !String.IsNullOrEmpty(this.AggregationPattern);
            }
        }

        public abstract bool Enabled { get; }


        private Func<string, string, bool, string> customSQLSegmentBuilder;


        protected EntitySQLFieldRelationItemBase()
            : this(null, null, null)
        {
        }

        protected EntitySQLFieldRelationItemBase(string fieldName)
            : this(fieldName, null, null)
        {
        }

        protected EntitySQLFieldRelationItemBase(string fieldName, Func<string, string, bool, string> customSQLSegmentBuilder)
            : this(fieldName, null, customSQLSegmentBuilder)
        {
        }

        protected EntitySQLFieldRelationItemBase(string fieldName, string aggregationPattern)
            : this(fieldName, aggregationPattern, null)
        {
        }

        protected EntitySQLFieldRelationItemBase(string fieldName, string aggregationPattern, Func<string, string, bool, string> customSQLSegmentBuilder)
        {
            //TODO: To handle "fieldName == null".
            this.FieldName = fieldName;
            this.AggregationPattern = aggregationPattern;
            this.customSQLSegmentBuilder = customSQLSegmentBuilder;
        }


        public string BuildEntitySQLSegment(string entityAlias, bool useAggregation)
        {
            string ret = null;
            string fieldNameSegment = this.BuildFieldNameSegment(entityAlias, useAggregation);
            if (this.customSQLSegmentBuilder == null)
            {
                ret = this.BuildEntitySQLSegmentFromFieldNameSegment(fieldNameSegment, useAggregation);
            }
            else
            {
                ret = this.customSQLSegmentBuilder(entityAlias, fieldNameSegment, useAggregation);
            }

            return ret;
        }

        public string BuildEntitySQLSegment(string entityAlias)
        {
            return this.BuildEntitySQLSegment(entityAlias, false);
        }

        protected virtual string BuildFieldNameSegment(string entityAlias, bool useAggregation)
        {
            string ret = this.FieldName;
            if (!String.IsNullOrEmpty(entityAlias))
            {
                ret = String.Format(FIELD_NAME_SEGMENT_PATTERN, entityAlias, ret);
            }
            if (useAggregation)
            {
                ret = this.FormatAggregationIfExist(ret);
            }

            return ret;
        }

        public string FormatAggregationIfExist(string fieldNameSegment)
        {
            string ret = fieldNameSegment;
            if (this.HasAggrgation)
            {
                ret = String.Format(this.AggregationPattern, fieldNameSegment);
            }

            return ret;
        }

        protected abstract string BuildEntitySQLSegmentFromFieldNameSegment(string fieldNameSegment, bool useAggregation);


        public static string[] BuildSQLSegments<TItem>(IList<TItem> items, string entityAlias, bool useAggregation, bool skipAggregation)
            where TItem : EntitySQLFieldRelationItemBase
        {
            string[] ret = null;
            if (items != null)
            {
                List<string> strs = new List<string>();
                foreach (TItem item in items)
                {
                    if (item.Enabled && (!skipAggregation || !item.HasAggrgation))
                    {
                        strs.Add(item.BuildEntitySQLSegment(entityAlias, useAggregation));
                    }
                }
                ret = strs.ToArray();
            }

            return ret;
        }

        public static string[] BuildSQLSegments<TItem>(IList<TItem> items, string entityAlias)
            where TItem : EntitySQLFieldRelationItemBase
        {
            return BuildSQLSegments<TItem>(items, entityAlias, false, false);
        }
    }
}
