using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.ParameterChecking.Validators
{
    public abstract class ValidatorBase : IParameterValidator
    {
        #region IParameterValidator Members

        public bool Validate(Parameter targetParameter, Parameter[] relatedParameters, out string errorMessage)
        {
            errorMessage = null;
            bool ret = this.DoValidate(targetParameter, relatedParameters);
            if (!ret)
            {
                errorMessage = this.GenerateErrorMessage(targetParameter);
            }

            return ret;
        }

        #endregion

        protected abstract bool DoValidate(Parameter targetParameter, Parameter[] relatedParameters);

        protected virtual string ErrorMessage
        {
            get
            {
                return null;
            }
        }

        protected virtual string GenerateErrorMessage(Parameter param)
        {
            string ret = this.ErrorMessage;
            if ((ret != null) && (param != null))
            {
                ret = String.Format(this.ErrorMessage, param.Name);
            }

            return ret;
        }
    }
}