using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.ParameterChecking.Validators
{
    public class GuidValidator : NotEmptyValidator
    {
        public new const string ERROR_MESSAGE = "Parameter must be in GUID format.";

        protected override string ErrorMessage
        {
            get
            {
                return ERROR_MESSAGE;
            }
        }

        protected override bool DoValidate(Parameter targetParameter, Parameter[] relatedParameters)
        {
            bool ret = false;
            if (base.DoValidate(targetParameter, relatedParameters))
            {
                try
                {
                    new Guid(targetParameter.Value);
                    ret = true;
                }
                catch (UriFormatException)
                {
                }
            }
            return ret;
        }
    }
}
