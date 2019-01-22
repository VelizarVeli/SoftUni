namespace SIS.Framework.Attributes
{
    using Methods;

    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
            => requestMethod.ToUpper() == "GET";
    }
}
