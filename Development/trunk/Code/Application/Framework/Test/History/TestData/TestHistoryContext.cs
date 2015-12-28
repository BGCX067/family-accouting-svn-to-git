using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.Utility.EdmExtension;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using Wang.Velika.FamilyAccounting.Application.Framework.History;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.History
{
    [ObjectContextMetadataMapping("TestData.DataModel")]
    partial class TestHistoryContext : IHistorySupport
    {
        public static TestHistoryContext CreateInstance()
        {
            return InformationCenter.States.DBInfo.RetrieveContext<TestHistoryContext>();
        }


        protected override void Dispose(bool disposing)
        {
            this.DetachAllObjects();

            base.Dispose(disposing);
        }

        #region IHistorySupport Members

        private HistoryCacheBag _historyCache = new HistoryCacheBag();
        HistoryCacheBag IHistorySupport.HistoryCache
        {
            get
            {
                return this._historyCache;
            }
        }

        #endregion
    }
}
