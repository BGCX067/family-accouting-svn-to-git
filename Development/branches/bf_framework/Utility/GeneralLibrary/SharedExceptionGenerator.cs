using System;
using System.Collections.Generic;
using System.Text;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public static class SharedExceptionGenerator
    {
        public static InvalidOperationException CreateModuleAlreadyInitializedException(string moduleName)
        {
            return new InvalidOperationException(String.Format(Resources.Culture, Resources._SharedException_Initializer_AlreadyInitialized, moduleName));
        }

        public static InvalidOperationException CreateModuleNotInitializedException(string moduleName, string itemName)
        {
            return new InvalidOperationException(String.Format(Resources.Culture, Resources._SharedException_Initializer_NotInitialized, moduleName, itemName));
        }
    }
}
