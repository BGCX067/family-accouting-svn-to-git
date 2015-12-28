using System.IO;
namespace Wang.Velika.Utility.ParameterChecking.Validators
{
    public class DirectoryExistsAndValidFileNameValidator : NotEmptyValidator
    {
        public new const string ERROR_MESSAGE = "Folder or file not exists";
        protected override string ErrorMessage
        {
            get
            {
                return ERROR_MESSAGE;
            }
        }
        protected override bool DoValidate(Parameter targetParameter, Parameter[] relatedParameters)
        {
            if (base.DoValidate(targetParameter,relatedParameters))
            {
                try
                {
                    FileInfo info = new FileInfo(targetParameter.Value);
                    if (info.Directory.Exists)
                    {
                        if (info.Name.EndsWith("\\") || info.Name.EndsWith("/"))
                        {

                            throw new FileNotFoundException();
                        }

                        return true;
                    }
                    else
                    {
                        throw new DirectoryNotFoundException();
                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}

