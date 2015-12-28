using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    public class CollectionChangeHolder
    {
        private List<ChangeMonitorBase> _changeMonitors;
        internal List<ChangeMonitorBase> ChangeMonitors
        {
            get
            {
                if (this._changeMonitors == null)
                {
                    this._changeMonitors = new List<ChangeMonitorBase>();
                }
                return this._changeMonitors;
            }
        }

        private List<ChangeEntry> _changedEntries;
        internal List<ChangeEntry> ChangedEntries
        {
            get
            {
                if (this._changedEntries == null)
                {
                    this._changedEntries = new List<ChangeEntry>();
                }
                return this._changedEntries;
            }
        }

        private List<HistoryPreparation> _cachedHistories;
        internal List<HistoryPreparation> CachedHistories
        {
            get
            {
                if (this._cachedHistories == null)
                {
                    this._cachedHistories = new List<HistoryPreparation>();
                }
                return this._cachedHistories;
            }
        }
    }
}
