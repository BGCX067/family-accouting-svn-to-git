using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Collections;

namespace Wang.Velika.Utility.WebLibrary
{
    public class RelatedControlCollection<TControl> : IList
        where TControl : Control
    {
        private List<TControl> controls;

        private IList ControlsAsIList
        {
            get
            {
                return (IList)this.controls;
            }
        }

        private ICollection ControlsAsICollection
        {
            get
            {
                return (ICollection)this.controls;
            }
        }

        private IEnumerable ControlsAsIEnumerable
        {
            get
            {
                return (IEnumerable)this.controls;
            }
        }


        private ControlCollection container;


        public RelatedControlCollection()
        {
            this.controls = new List<TControl>();
        }


        public void SetContainer(ControlCollection targetContainer)
        {
            foreach (Control ctl in this.controls)
            {
                if (this.container != null)
                {
                    this.container.Remove(ctl);
                }
                if (targetContainer != null)
                {
                    targetContainer.Add(ctl);
                }
            }
            this.container = targetContainer;
        }


        #region IList Members

        public int Add(object value)
        {
            int ret = this.ControlsAsIList.Add(value);
            if (this.container != null)
            {
                this.container.Add((Control)value);
            }
            return ret;
        }

        void IList.Clear()
        {
            this.ControlsAsIList.Clear();
            if (this.container != null)
            {
                this.container.Clear();
            }
        }

        public bool Contains(object value)
        {
            return this.ControlsAsIList.Contains(value);
        }

        public int IndexOf(object value)
        {
            return this.ControlsAsIList.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            this.ControlsAsIList.Insert(index, value);
            if (this.container != null)
            {
                this.container.AddAt(index, (Control)value);
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return this.ControlsAsIList.IsFixedSize;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return this.ControlsAsIList.IsReadOnly;
            }
        }

        public void Remove(object value)
        {
            this.ControlsAsIList.Remove(value);
            if (this.container != null)
            {
                this.container.Remove((Control)value);
            }
        }

        public void RemoveAt(int index)
        {
            this.ControlsAsIList.RemoveAt(index);
            if (this.container != null)
            {
                this.container.RemoveAt(index);
            }
        }

        public object this[int index]
        {
            get
            {
                return this.ControlsAsIList[index];
            }
            set
            {
                this.ControlsAsIList[index] = value;
            }
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            this.ControlsAsICollection.CopyTo(array, index);
        }

        int ICollection.Count
        {
            get
            {
                return this.ControlsAsICollection.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this.ControlsAsICollection.IsSynchronized;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this.ControlsAsICollection.SyncRoot;
            }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.ControlsAsIEnumerable.GetEnumerator();
        }

        #endregion
    }
}
