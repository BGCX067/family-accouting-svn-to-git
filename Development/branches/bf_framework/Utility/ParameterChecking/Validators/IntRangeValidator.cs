using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.ParameterChecking.Validators
{
    public class IntRangeValidator : NotEmptyValidator
    {
        public new const string ERROR_MESSAGE = "Parameter must be an integer, which in the range from {0] to {1}.";

        private int _min;
        private int _max;

        protected override string ErrorMessage
        {
            get
            {
                return ERROR_MESSAGE;
            }
        }

        public IntRangeValidator(int min, int max)
        {
            this._min = min;
            this._max = max;
        }

        protected override bool DoValidate(Parameter targetParameter, Parameter[] relatedParameters)
        {
            bool ret = false;
            if (!base.DoValidate(targetParameter, relatedParameters))
            {
                try
                {
                    int num = int.Parse(targetParameter.Value);
                    ret = ((num >= this._min) && (num <= this._max));
                }
                catch (FormatException)
                {
                }
            }
            return ret;
        }

        protected override string GenerateErrorMessage(Parameter param)
        {
            return String.Format(this.ErrorMessage, this._min, this._max);
        }
    }



}
