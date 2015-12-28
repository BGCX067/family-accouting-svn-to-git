using System;
using System.Collections.Generic;
using System.Text;

namespace Wang.Velika.Utility.GeneralLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// This is only for providing information. There is not any automatical process.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class AssemblyInitializerAttribute : Attribute
    {
        private Type _initializerType;
        public Type InitializerType 
        {
            get
            {
                return this._initializerType;
            }
            set
            {
                this._initializerType = value;
            }
        }

        private string _initializerMethodName;
        public string InitializerMethodName 
        {
            get 
            {
                return this._initializerMethodName;
            }
            set
            {
                this._initializerMethodName = value;
            }

        }

        private bool _canReinitialize;
        public bool CanReinitialize
        {
            get
            {
                return this._canReinitialize;
            }
            set 
            {
                this._canReinitialize = value;
            }
        }


        public AssemblyInitializerAttribute(Type initializerType, string initializerMethodName, bool canReinitialize)
        {
            this.InitializerType = initializerType;
            this.InitializerMethodName = initializerMethodName;
            this.CanReinitialize = canReinitialize;
        }
    }
}
