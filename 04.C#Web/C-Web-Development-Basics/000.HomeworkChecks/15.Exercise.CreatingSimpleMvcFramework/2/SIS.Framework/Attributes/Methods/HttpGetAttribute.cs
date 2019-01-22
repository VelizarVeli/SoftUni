namespace SIS.Framework.Attributes.Methods
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string reuqestMethod)
        {
            if (reuqestMethod.ToUpper() == "GET")
            {
                return true;
            }

            return false;
        }
    }
}