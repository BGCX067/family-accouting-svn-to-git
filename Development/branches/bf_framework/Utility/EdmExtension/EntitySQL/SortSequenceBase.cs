using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public abstract class SortSequenceBase
    {
        protected Dictionary<EntitySQLFieldNameWithAggregation, int> Items { get; private set; }


        protected SortSequenceBase()
        {
            this.Items = new Dictionary<EntitySQLFieldNameWithAggregation, int>();
        }


        protected int? GetItemValue(string key)
        {
            int? ret = null;
            int seq;
            if (this.Items.TryGetValue(new EntitySQLFieldNameWithAggregation(key), out seq))
            {
                ret = seq;
            }

            return ret;
        }

        protected void SetItemValue(string key, string aggregationPattern, int? v)
        {
            EntitySQLFieldNameWithAggregation pair = new EntitySQLFieldNameWithAggregation(key, aggregationPattern);
            if (v.HasValue)
            {
                this.Items[pair] = v.Value;
            }
            else
            {
                this.Items.Remove(pair);
            }
        }

        protected void SetItemValue(string key, int? v)
        {
            this.SetItemValue(key, null, v);
        }

        internal void FillQuerySorts(List<EntitySQLSortItem> sorts, EntitySQLQueryWrapper wrapper)
        {
            IDictionary<EntitySQLFieldNameWithAggregation, int> items = this.PrepareItemsBeforeFilling(wrapper);
            if (items != null)
            {
                foreach (KeyValuePair<EntitySQLFieldNameWithAggregation, int> item in items.OrderBy(x => Math.Abs(x.Value)))
                {
                    if (item.Value > 0)
                    {
                        sorts.Add(new EntitySQLSortItem(item.Key.Name, item.Key.AggregationPattern, EntitySQLSortDirection.Ascending));
                    }
                    if (item.Value < 0)
                    {
                        sorts.Add(new EntitySQLSortItem(item.Key.Name, item.Key.AggregationPattern, EntitySQLSortDirection.Descending));
                    }
                }
            }
        }

        protected virtual IDictionary<EntitySQLFieldNameWithAggregation, int> PrepareItemsBeforeFilling(EntitySQLQueryWrapper wrapper)
        {
            IDictionary<EntitySQLFieldNameWithAggregation, int> ret = new Dictionary<EntitySQLFieldNameWithAggregation, int>(this.Items);

            if (ret.Count <= 0)
            {
                this.AddDefaultItems(ret, wrapper);
            }

            return ret;
        }

        protected virtual void AddDefaultItems(IDictionary<EntitySQLFieldNameWithAggregation, int> items, EntitySQLQueryWrapper wrapper)
        {
        }
    }
}
