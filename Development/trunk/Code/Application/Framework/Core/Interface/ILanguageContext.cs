using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;


namespace Wang.Velika.FamilyAccounting.Application.Framework.Core
{
    public interface ILanguageContext
    {
        int? LanguageID { get; }

        CultureInfo Culture { get; }

        IResourceProvider ResourceProvider { get; }
    }
}
