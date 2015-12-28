using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.ParameterChecking.Validators
{
    public class NotEmptyValidator : ValidatorBase
    {
        public const string ERROR_MESSAGE = "Parameter can not be empty.";

        protected override string ErrorMessage
        {
            get
            {
                return ERROR_MESSAGE;
            }
        }

        protected override bool DoValidate(Parameter targetParameter, Parameter[] relatedParameters)
        {
            return ((targetParameter != null) && !String.IsNullOrEmpty(targetParameter.Value));
        }
    }
}
