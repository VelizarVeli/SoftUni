namespace SIS.Framework.Attributes
{
    using Methods;

    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
            => requestMethod.ToUpper() == "POST";
    }
}
