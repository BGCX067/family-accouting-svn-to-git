using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace Wang.Velika.FamilyAccounting.Application.Framework.ExceptionHandling
{
    [Serializable]
    public abstract class CodableExceptionBase : ApplicationException
    {
        public const string ERRORCODE_KEY_IN_EXCEPTION_DATA = "ErrorCode";


        public string ErrorCode
        {
            get
            {
                return (string)this.Data[ERRORCODE_KEY_IN_EXCEPTION_DATA];
            }
            private set
            {
                this.Data[ERRORCODE_KEY_IN_EXCEPTION_DATA] = value;
            }
        }


        protected CodableExceptionBase(string errorCode, string message, Exception innerEx)
            :base(message, innerEx)
        {
            this.ErrorCode = errorCode;
        }

        protected CodableExceptionBase(string errorCode, string message)
            : this(errorCode, message, null)
        {
        }

        protected CodableExceptionBase(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
