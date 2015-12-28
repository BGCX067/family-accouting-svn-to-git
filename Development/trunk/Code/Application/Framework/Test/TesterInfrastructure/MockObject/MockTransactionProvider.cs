using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using System.Transactions;


namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure
{
    public class MockTransactionProvider : ITransactionProvider
    {
        private TransactionScope scope;


        public MockTransactionProvider()
        {
            TransactionScopeOption scopeOption = TransactionScopeOption.Required;
            TransactionOptions transOption = new TransactionOptions();
            transOption.IsolationLevel = IsolationLevel.ReadCommitted;

            this.scope = new TransactionScope(scopeOption, transOption);
        }


        #region ITransactionProvider Members

        void ITransactionProvider.ReadyToCommit()
        {
            this.scope.Complete();
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            this.scope.Dispose();
        }

        #endregion
    }
}
