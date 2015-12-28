using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wang.Velika.FamilyAccounting.Application.Framework.Core
{
    public interface IStateRepository
    {
        IUserContext UserInfo { get; }

        ILanguageContext LanguageInfo { get; }

        IDBContext DBInfo { get; }

        IDictionary<string, IDBContext> DBInfoPool { get; }

        ITransactionContext TransactionInfo { get; }
    }
}
