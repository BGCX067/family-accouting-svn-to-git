using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using Wang.Velika.FamilyAccounting.Application.Framework.History;
using System.Transactions;


namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure
{
    public class MockTransactionContext : ITransactionContext
    {
        public virtual ApplicationTransaction ApplicationTransactionInstance { get; set; }


        public MockTransactionContext()
        {
        }


        public void InitApplicationTransaction()
        {
            this.ApplicationTransactionInstance = new ApplicationTransaction();
            using (HistoryContext ctx = HistoryContext.CreateInstance())
            {
                ctx.AddToApplicationTransactionSet(this.ApplicationTransactionInstance);
                ctx.SaveChanges();
            }
        }

        public virtual ITransactionProvider BuildTransactionProvider()
        {
            return new MockTransactionProvider();
        }


        #region ITransactionContext Members

        int? ITransactionContext.ApplicationTransactionIdentifier
        {
            get
            {
                return this.ApplicationTransactionInstance.ID;
            }
        }

        ITransactionProvider ITransactionContext.BuildTransactionProvider()
        {
            return this.BuildTransactionProvider();
        }

        #endregion
    }
}
