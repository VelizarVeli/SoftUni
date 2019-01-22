namespace SIS.Framework.Attributes.Methods
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string reuqestMethod)
        {
            if (reuqestMethod.ToUpper() == "POST")
            {
                return true;
            }

            return false;
        }
    }
}