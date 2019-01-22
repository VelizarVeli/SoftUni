namespace SIS.Framework.Attributes
{
    using Methods;

    public class HttpPutAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
            => requestMethod.ToUpper() == "PUT";
    }
}
