using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure
{
    public abstract class FakeDBOperationTesterBase : DefaultMockTesterBase
    {
        protected ITransactionProvider TransactionProvider { get; private set; }

        public override void FixtureSetUp()
        {
            this.TransactionProvider = new MockTransactionProvider();
            base.FixtureSetUp();
        }

        public override void FixtureTearDown()
        {
            base.FixtureTearDown();
            this.TransactionProvider.Dispose();
        }
    }
}
