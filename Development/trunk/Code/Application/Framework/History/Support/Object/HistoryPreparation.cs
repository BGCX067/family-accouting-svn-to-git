using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    internal class HistoryPreparation
    {
        public ChangeEntry Change { get; private set; }

        private IList<RawChangeHistory> _relations;
        public IList<RawChangeHistory> Relations
        {
            get
            {
                if (this._relations == null)
                {
                    this._relations = new List<RawChangeHistory>();
                }
                return this._relations;
            }
        }

        private IList<EntityObject> _entities;
        public IList<EntityObject> Entities
        {
            get
            {
                if (this._entities == null)
                {
                    this._entities = new List<EntityObject>();
                }
                return this._entities;
            }
        }


        public HistoryPreparation(ChangeEntry change)
        {
            this.Change = change;
        }
    }
}
