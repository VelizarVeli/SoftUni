namespace SIS.Framework.Attributes.Methods
{
    public class HttpDeleteAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string reuqestMethod)
        {
            if (reuqestMethod.ToUpper() == "DELETE")
            {
                return true;
            }

            return false;
        }
    }
}