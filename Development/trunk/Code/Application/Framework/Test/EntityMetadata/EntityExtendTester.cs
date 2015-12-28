using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;
using System.Data.Objects.DataClasses;
using Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure;
using System.Data;


namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.EntityMetadata
{
    public class EntityExtendTester : FakeDBOperationTesterBase
    {
        class TestClass1 : EntityObject, IEntityExtend
        {
            #region IEntityExtend Members

            public int EntityTypeID
            {
                get
                {
                    return 101;
                }
            }

            public int EntityID
            {
                get
                {
                    return 0;
                }
            }

            #endregion
        }


        [Test]
        public void Test()
        {
            TestClass1 o = new TestClass1();
            EntityTypeInfo et = o.GetEntityInfo();
            Assert.IsNotNull(et);
            Assert.AreEqual(101, et.ID);
            Assert.AreEqual(EntityState.Detached, et.EntityState);
        }
    }
}
