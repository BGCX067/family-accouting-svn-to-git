using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using Wang.Velika.FamilyAccounting.Application.Framework.History;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Globalization
{
    public class ResourceProvider : IResourceProvider
    {
        public string GetString(string resourceKey, int? languageID, params object[] args)
        {
            LanguageSet lang = new LanguageSet();

            return null;
        }


        #region IResourceProvider Members

        string IResourceProvider.GetString(string resourceKey, int? languageID, params object[] args)
        {
            return this.GetString(resourceKey, languageID, args);
        }

        #endregion
    }
}
