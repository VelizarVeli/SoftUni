namespace SIS.Framework.Attributes
{
    using Methods;

    public class HttpDeleteAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
            => requestMethod.ToUpper() == "DELETE";
    }
}
