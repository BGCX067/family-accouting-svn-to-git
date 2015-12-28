using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using System.Globalization;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure
{
    public class MockLanguageContext : ILanguageContext
    {
        public virtual int? LanguageID { get; set; }

        public virtual CultureInfo Culture { get; set; }

        public virtual MockResourceProvider ResourceProvider { get; set; }


        public MockLanguageContext()
        {
            this.ResourceProvider = new MockResourceProvider();
        }


        #region ILanguageContext Members

        int? ILanguageContext.LanguageID
        {
            get
            {
                return this.LanguageID;
            }
        }

        CultureInfo ILanguageContext.Culture
        {
            get
            {
                return this.Culture;
            }
        }

        IResourceProvider ILanguageContext.ResourceProvider
        {
            get
            {
                return this.ResourceProvider;
            }
        }

        #endregion
    }
}
