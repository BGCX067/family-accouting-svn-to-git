using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.ParameterChecking
{
    public interface IParameterValidator
    {
        bool Validate(Parameter targetParameter, Parameter[] relatedParameters, out string errorMessage);
    }
}
