using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public class EntitySQLQueryWrapper
    {
        private const string FILTER_CONDITIONS_SEPERATOR = " AND ";
        private const string GROUP_CONDITIONS_SEPERATOR = " , ";
        private const string SORT_CONDITIONS_SEPERATOR = " , ";


        public List<EntitySQLFilterItem> Filters { get; set; }

        public EntitySQLGroupItem GroupBy { get; set; }

        public List<EntitySQLSortItem> Sorts { get; set; }

        public int? StartIndex { get; set; }

        public int? Count { get; set; }

        public bool HasGroup
        {
            get
            {
                return (this.GroupBy != null);
            }
        }


        public EntitySQLQueryWrapper()
        {
            this.Filters = new List<EntitySQLFilterItem>();
            this.Sorts = new List<EntitySQLSortItem>();
        }


        public string BuildFilterSegment(string entityAlias)
        {
            string ret = null;
            string[] segs = EntitySQLFieldRelationItemBase.BuildSQLSegments<EntitySQLFilterItem>(this.Filters, entityAlias);
            if (segs != null)
            {
                ret = String.Join(FILTER_CONDITIONS_SEPERATOR, segs);
            }

            return ret;
        }

        private List<EntitySQLGroupItem> GetGroupItems()
        {
            List<EntitySQLGroupItem> ret = null;
            if (this.GroupBy != null)
            {
                ret = new List<EntitySQLGroupItem>();
                ret.Add(this.GroupBy);
                foreach (EntitySQLSortItem sort in this.Sorts)
                {
                    if (!String.Equals(this.GroupBy.FieldName, sort.FieldName, StringComparison.OrdinalIgnoreCase))
                    {
                        ret.Add(new EntitySQLGroupItem(sort.FieldName, sort.AggregationPattern));
                    }
                }
            }

            return ret;
        }

        public string BuildGroupSegment(string entityAlias, out string projection)
        {
            List<EntitySQLGroupItem> groups = this.GetGroupItems();
            string ret = null;
            projection = null;
            if (groups != null)
            {
                string[] segsKey = EntitySQLFieldRelationItemBase.BuildSQLSegments<EntitySQLGroupItem>(groups, entityAlias, false, true);
                if (segsKey != null)
                {
                    ret = String.Join(GROUP_CONDITIONS_SEPERATOR, segsKey);
                }
                string[] segsProjection = EntitySQLFieldRelationItemBase.BuildSQLSegments<EntitySQLGroupItem>(groups, entityAlias, true, false);
                if (segsProjection != null)
                {
                    projection = String.Join(GROUP_CONDITIONS_SEPERATOR, segsProjection);
                }
            }

            return ret;
        }

        public string BuildSortSegment(string entityAlias)
        {
            string ret = null;
            string[] segs = EntitySQLFieldRelationItemBase.BuildSQLSegments<EntitySQLSortItem>(this.Sorts, entityAlias);
            if (segs != null)
            {
                ret = String.Join(SORT_CONDITIONS_SEPERATOR, segs);
            }

            return ret;
        }


        public void FillFromSearchCriteria(SearchCriteriaBase criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException("criteria");
            }

            if (this.Filters == null)
            {
                this.Filters = new List<EntitySQLFilterItem>();
            }
            criteria.FillQueryFilters(this.Filters, this);
        }

        public void FillFromSortSequence(SortSequenceBase sortSequence)
        {
            if (sortSequence == null)
            {
                throw new ArgumentNullException("sortSequence");
            }

            if (this.Sorts == null)
            {
                this.Sorts = new List<EntitySQLSortItem>();
            }
            sortSequence.FillQuerySorts(this.Sorts, this);
        }

        public void FillFromPagingInfo(PagingInfo pagingInfo)
        {
            if (pagingInfo == null)
            {
                throw new ArgumentNullException("pagingInfo");
            }

            this.StartIndex = pagingInfo.StartIndex;
            this.Count = pagingInfo.Count;
        }

        public static EntitySQLQueryWrapper BuildEntitySQLQueryWrapper(SearchCriteriaBase criteria, PagingInfo pagingInfo, SortSequenceBase sortSequence)
        {
            EntitySQLQueryWrapper ret = new EntitySQLQueryWrapper();
            if (criteria != null)
            {
                ret.FillFromSearchCriteria(criteria);
            }
            if (sortSequence != null)
            {
                ret.FillFromSortSequence(sortSequence);
            }
            if (pagingInfo != null)
            {
                ret.FillFromPagingInfo(pagingInfo);
            }

            return ret;
        }

        public static EntitySQLQueryWrapper BuildEntitySQLQueryWrapper(ISearchDataWrapper searchData)
        {
            if (searchData == null)
            {
                throw new ArgumentNullException("searchData");
            }

            return BuildEntitySQLQueryWrapper(searchData.SearchCriteria, searchData.Paging, searchData.SortSequence);
        }
    }
}
