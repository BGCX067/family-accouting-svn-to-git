using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure
{
    public class MockResourceProvider : IResourceProvider
    {
        public string GetString(string resourceKey, int? languageID, params object[] args)
        {
            return resourceKey;
        }


        #region IResourceProvider Members

        string IResourceProvider.GetString(string resourceKey, int? languageID, params object[] args)
        {
            return this.GetString(resourceKey, languageID, args);
        }

        #endregion
    }
}
