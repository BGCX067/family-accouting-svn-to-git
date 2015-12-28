using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;


namespace Wang.Velika.FamilyAccounting.Application.Framework.Core
{
    public interface IUserContext
    {
        int? UserIdentifier { get; }

        int? AuthorityIdentifier { get; }

        bool RunAsSuper { get; }
    }
}
