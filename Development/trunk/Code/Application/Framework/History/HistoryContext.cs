using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using Wang.Velika.Utility.EdmExtension;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    [ObjectContextMetadataMapping("DataModel")]
    partial class HistoryContext
    {
        public static HistoryContext CreateInstance()
        {
            return InformationCenter.States.DBInfo.RetrieveContext<HistoryContext>();
        }


        protected override void Dispose(bool disposing)
        {
            this.DetachAllObjects();

            base.Dispose(disposing);
        }


        public ApplicationTransaction GetApplicationTransaction(int id)
        {
            var ret = from at in this.ApplicationTransactionSet
                      where at.ID == id
                      select at;

            return ret.FirstOrDefault();
        }

        public IEnumerable<CoreHistory> FindHistories(int entityTypeID, int? entityID)
        {
            var ret = from hist in this.CoreHistorySet
                      where hist.EntityTypeID == entityTypeID
                      select hist;
            if (entityID.HasValue)
            {
                ret = ret.Where(x => x.EntityID == entityID.Value);
            }
            ret = ret.OrderByDescending(x => x.Timestamp);

            return ret;
        }
    }
}
