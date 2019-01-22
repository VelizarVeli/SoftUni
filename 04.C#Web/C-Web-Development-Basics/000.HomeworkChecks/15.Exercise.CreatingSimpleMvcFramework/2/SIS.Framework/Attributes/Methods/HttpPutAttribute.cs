namespace SIS.Framework.Attributes.Methods
{
    public class HttpPutAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string reuqestMethod)
        {
            if (reuqestMethod.ToUpper() == "PUT")
            {
                return true;
            }

            return false;
        }
    }
}