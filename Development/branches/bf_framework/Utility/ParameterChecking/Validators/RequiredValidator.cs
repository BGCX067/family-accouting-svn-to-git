using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.ParameterChecking.Validators
{
    public class RequiredValidator : NotEmptyValidator
    {
        public new const string ERROR_MESSAGE = "Parameter is required, must exist and not be empty.";

        protected override string ErrorMessage
        {
            get
            {
                return ERROR_MESSAGE;
            }
        }
    }
}
