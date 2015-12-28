using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.Utility.EdmExtension;
using System.Configuration;


namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure
{
    public abstract class DefaultMockTesterBase : TesterBase<MockStateRepository>
    {
        public const string CONFIGURATION_SECTION_PATH_DATABASE = "familyAccounting/database";


        public override void FixtureSetUp()
        {
            base.FixtureSetUp();

            MockStateRepository.DatabaseInformation = (DatabaseInformationSection)ConfigurationManager.OpenExeConfiguration(null).GetSection(CONFIGURATION_SECTION_PATH_DATABASE);
        }

        public override void SetUp()
        {
            base.SetUp();

            MockStateRepository.CurrentInstance.TransactionInfo.InitApplicationTransaction();
        }
    }
}
