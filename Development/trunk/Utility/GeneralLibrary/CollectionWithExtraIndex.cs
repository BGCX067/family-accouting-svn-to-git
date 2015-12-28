using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public class CollectionWithExtraIndex<TItem, TIndex>
        : List<TItem>
    {
        private PropertyInfo indexProperty;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Default implementation is returning <b>false</b>.
        /// </remarks>
        protected virtual bool AllowNullIndex
        {
            get
            {
                return false;
            }
        }


        public CollectionWithExtraIndex(string indexPropertyName, IEnumerable<TItem> items)
        {
            if (indexPropertyName == null)
            {
                throw new ArgumentNullException("indexPropertyName");
            }


            this.indexProperty = typeof(TItem).GetProperty(indexPropertyName);
            this.AddRange(items, false);
        }

        public CollectionWithExtraIndex(string indexPropertyName)
            : this(indexPropertyName, null)
        {
        }


        public TItem this[TIndex index]
        {
            get
            {
                if (!this.CheckIndexAllowedNull(index))
                {
                    throw new ArgumentNullException("index");
                }


                return base.Find(
                    delegate(TItem item) { return this.AssertEqual(item, index); }
                    );
            }
            set
            {
                if (!this.CheckIndexAllowedNull(index))
                {
                    throw new ArgumentNullException("index");
                }
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }


                int pos = this.FindIndex(
                    delegate(TItem item) { return this.AssertEqual(item, index); }
                    );
                if (0 > pos)
                {
                    base.Add(value);
                }
                else
                {
                    base[pos] = value;
                }
            }
        }

        protected TIndex GetItemIndexValue(TItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }


            return (TIndex)this.indexProperty.GetValue(item, null);
        }

        private bool AssertEqual(TItem item, TIndex index)
        {
            return ((null != item) && Object.Equals(this.GetItemIndexValue(item), index));
        }

        public void AddItem(TItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }


            if (!Object.Equals(item, null))
            {
                this[this.GetItemIndexValue(item)] = item;
            }
        }

        public new virtual void Add(TItem item)
        {
            this.Add(item, true);
        }

        public void Add(TItem item, bool overwriteExisting)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }


            if (overwriteExisting)
            {
                this.AddItem(item);
            }
            else
            {
                if (!this.CheckIndexAllowedNull(this.GetItemIndexValue(item)))
                {
                    throw new ArgumentNullException(String.Format(Resources.Culture, "item.{0}", this.indexProperty));
                }


                base.Add(item);
            }
        }

        public bool Contains(TIndex index)
        {
            return (null != this[index]);
        }

        public new virtual void AddRange(IEnumerable<TItem> items)
        {
            this.AddRange(items, true);
        }

        public void AddRange(IEnumerable<TItem> items, bool overwriteExisting)
        {
            if (null != items)
            {
                foreach (TItem item in items)
                {
                    this.Add(item, overwriteExisting);
                }
            }
        }

        private bool CheckIndexAllowedNull(TIndex index)
        {
            return (this.AllowNullIndex || typeof(TIndex).IsValueType || (index != null));
        }


        public static TCollection MergeCollections<TCollection>(bool overwriteExisting, params TCollection[] collections)
            where TCollection : CollectionWithExtraIndex<TItem, TIndex>, new()
        {
            TCollection ret = new TCollection();
            foreach (CollectionWithExtraIndex<TItem, TIndex> collection in collections)
            {
                ret.AddRange(collection, overwriteExisting);
            }
            return ret;
        }
    }
}
