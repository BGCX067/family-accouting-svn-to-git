using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.Utility.GeneralLibrary;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Core
{
    public static class InformationCenter
    {
        private static IStateRepository _states;
        public static IStateRepository States
        {
            get
            {
                lock (lockerForInitialization)
                {
                    if (_states == null)
                    {
                        ThrowNotInitialized("states");
                    }

                    return _states;
                }
            }
        }

        private static ApplicationSectionGroup _configurationGroup;
        public static ApplicationSectionGroup ConfigurationGroup
        {
            get
            {
                lock (lockerForInitialization)
                {
                    if (_configurationGroup == null)
                    {
                        ThrowNotInitialized("configurationGroup");
                    }

                    return _configurationGroup;
                }
            }
        }

        private static bool initialized;
        private static object lockerForInitialization;


        static InformationCenter()
        {
            lockerForInitialization = new object();
        }


        public static void Initialize(IStateRepository states, ApplicationSectionGroup configurationGroup)
        {
            lock (lockerForInitialization)
            {
                if (initialized)
                {
                    throw SharedExceptionGenerator.CreateModuleAlreadyInitializedException(typeof(InformationCenter).Assembly.GetName().Name);
                }
                if (states == null)
                {
                    throw new ArgumentNullException("states");
                }
                if (configurationGroup == null)
                {
                    throw new ArgumentNullException("configurationGroup");
                }

                _states = states;
                _configurationGroup = configurationGroup;

                initialized = true;
            }
        }

        private static void ThrowNotInitialized(string itemName)
        {
            throw SharedExceptionGenerator.CreateModuleNotInitializedException(typeof(InformationCenter).Assembly.GetName().Name, itemName);
        }
    }
}
