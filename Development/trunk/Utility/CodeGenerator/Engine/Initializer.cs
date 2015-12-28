using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.Utility.GeneralLibrary;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public static class Initializer
    {
        private static CodeGeneratorSection _configRoot;
        internal static CodeGeneratorSection ConfigRoot
        {
            get
            {
                if (_configRoot == null)
                {
                    throw SharedExceptionGenerator.CreateModuleNotInitializedException("CodeGenerator", "ConfigRoot");
                }

                return _configRoot;
            }
        }


        public static void Initialize(CodeGeneratorSection configRoot)
        {
            if (configRoot == null)
            {
                throw new ArgumentNullException("configRoot");
            }

            _configRoot = configRoot;
        }
    }
}
