using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.ParameterChecking.Validators
{
    public class UrlValidator : NotEmptyValidator
    {
        public new const string ERROR_MESSAGE = "Parameter is not in correct url format.";

        protected override string ErrorMessage
        {
            get
            {
                return ERROR_MESSAGE;
            }
        }

        protected override bool DoValidate(Parameter targetParameter, Parameter[] relatedParameters)
        {
            bool flag = false;
            if (base.DoValidate(targetParameter, relatedParameters))
            {
                if (targetParameter.Value.IndexOf('\\') < 0)
                {
                    try
                    {
                        Uri uri = new Uri(targetParameter.Value);
                        if (String.IsNullOrEmpty(uri.Fragment))
                        {
                            if (String.IsNullOrEmpty(uri.Query))
                            {
                                flag = ((uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps));
                            }
                        }
                    }
                    catch (UriFormatException)
                    {
                    }
                }
            }

            return flag;
        }
    }

}

