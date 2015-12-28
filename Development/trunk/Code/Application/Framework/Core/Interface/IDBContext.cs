using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;


namespace Wang.Velika.FamilyAccounting.Application.Framework.Core
{
    public interface IDBContext
    {
        DbConnection Connection { get; }

        TContext RetrieveContext<TContext>() where TContext : class;
    }
}
