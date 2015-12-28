using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using System.Configuration;
using NUnit.Framework;


namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure
{
    [TestFixture]
    public abstract class TesterBase<TStateRepository>
        where TStateRepository : IStateRepository, new()
    {
        public const string CONFIGURATION_SECTION_GROUP_PATH_APPLICATION = "familyAccounting";

        
        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            InformationCenter.Initialize(
                new TStateRepository(),
                (ApplicationSectionGroup)ConfigurationManager.OpenExeConfiguration(null).GetSectionGroup(CONFIGURATION_SECTION_GROUP_PATH_APPLICATION)
                );
        }

        [TestFixtureTearDown]
        public virtual void FixtureTearDown()
        {
        }
        
        [SetUp]
        public virtual void SetUp()
        {
        }

        [TearDown]
        public virtual void TearDown()
        {
        }

    }
}
