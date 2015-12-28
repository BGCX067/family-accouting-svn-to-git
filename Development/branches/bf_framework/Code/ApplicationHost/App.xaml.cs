using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Wang.Velika.Utility.EdmExtension;
using Wang.Velika.FamilyAccounting.BizLogic;

namespace Wang.Velika.FamilyAccounting.ApplicationHost
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string CONFIGURATION_SECTION_PATH_DATABASE = "database";

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(null);
            DatabaseInformationSection dbSec = (DatabaseInformationSection)config.GetSection(CONFIGURATION_SECTION_PATH_DATABASE);
            EnvironmentHolder.Initialize(dbSec);
        }
    }
}
