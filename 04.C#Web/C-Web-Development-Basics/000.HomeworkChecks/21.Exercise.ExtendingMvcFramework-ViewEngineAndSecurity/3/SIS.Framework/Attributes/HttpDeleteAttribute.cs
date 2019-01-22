namespace SIS.Framework.Attributes
{
    public class HttpDeleteAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "DELETE")
            {
                return true;
            }

            return false;
        }
    }
}