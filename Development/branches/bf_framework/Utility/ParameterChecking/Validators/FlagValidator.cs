using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.ParameterChecking.Validators
{
    public class FlagValidator : ValidatorBase
    {
        public const string ERROR_MESSAGE = "Parameter must exist.";

        protected override string ErrorMessage
        {
            get
            {
                return ERROR_MESSAGE;
            }
        }

        protected override bool DoValidate(Parameter targetParameter, Parameter[] relatedParameters)
        {
            return ((targetParameter != null) && (targetParameter.Value != null));
        }
    }
}
