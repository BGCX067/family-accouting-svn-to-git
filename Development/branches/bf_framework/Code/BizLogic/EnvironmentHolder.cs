using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.Utility.EdmExtension;
using Wang.Velika.Utility.GeneralLibrary;
using System.Data.Common;

namespace Wang.Velika.FamilyAccounting.BizLogic
{
    public static class EnvironmentHolder
    {
        private static DatabaseInformationSection _dbInfoSection;
        public static DatabaseInformationSection DBInfoSection
        {
            get
            {
                lock (lockerForInitialization)
                {
                    if (_dbInfoSection == null)
                    {
                        ThrowNotInitialized("dbInfoSection");
                    }

                    return _dbInfoSection;
                }
            }
        }

        private static bool initialized;
        private static object lockerForInitialization;
        private static object lockerForConnection;

        internal static ObjectContextAssistant ContextAssistant { get; private set; }


        static EnvironmentHolder()
        {
            lockerForInitialization = new object();
            lockerForConnection = new object();

            ContextAssistant = new ObjectContextAssistant();
        }


        public static void Initialize(DatabaseInformationSection dbInfoSection)
        {
            lock (lockerForInitialization)
            {
                if (initialized)
                {
                    throw SharedExceptionGenerator.CreateModuleAlreadyInitializedException(typeof(EnvironmentHolder).Assembly.GetName().Name);
                }
                if (dbInfoSection == null)
                {
                    throw new ArgumentNullException("dbInfoSection");
                }

                _dbInfoSection = dbInfoSection;

                initialized = true;
            }
        }

        private static void ThrowNotInitialized(string itemName)
        {
            throw SharedExceptionGenerator.CreateModuleNotInitializedException(typeof(EnvironmentHolder).Assembly.GetName().Name, itemName);
        }


        private static DbConnection _connection;
        public static DbConnection Connection
        {
            get
            {
                lock (lockerForConnection)
                {
                    if (_connection == null)
                    {
                        _connection = ContextAssistant.CreateConnectionForContext(DBInfoSection.Provider, DBInfoSection.ConnectionString);
                    }
                    return _connection;
                }
            }
        }
    }
}
