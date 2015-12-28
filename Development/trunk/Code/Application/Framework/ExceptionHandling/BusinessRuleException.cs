using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace Wang.Velika.FamilyAccounting.Application.Framework.ExceptionHandling
{
    [Serializable]
    public class BusinessRuleException : CodableExceptionBase
    {
        protected BusinessRuleException(string code, string message)
            : this(code, message, null)
        {
        }

        protected BusinessRuleException(string code, string message, Exception innerEx)
            : base(code, message, innerEx)
        {
        }

        protected BusinessRuleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }


        public static BusinessRuleException CreateException(string code, params object[] args)
        {
            return new BusinessRuleException(code, ExceptionWithGlobalizationGenerator.ParseResourceString<BusinessRuleException>(code, args));
        }
    }
}
