using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure;
using Wang.Velika.FamilyAccounting.Application.Framework.History;
using Wang.Velika.FamilyAccounting.Application.Framework.Globalization;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.Globalization
{
    public class ResourceProviderTester : FakeDBOperationTesterBase
    {
        [Test]
        public void TestGetString()
        {
            ResourceProvider rp = new ResourceProvider();
            string str = rp.GetString("Test", null);
        }

        [Test]
        public void Test()
        {
            using (GlobalizationContext ctx = GlobalizationContext.CreateInstance())
            {
                LanguageSet lang = new LanguageSet();
                lang.Name = "test";
                ctx.AddToLanguageSetSet(lang);
                ctx.SaveChangesWithHistory();
            }
        }
    }
}
