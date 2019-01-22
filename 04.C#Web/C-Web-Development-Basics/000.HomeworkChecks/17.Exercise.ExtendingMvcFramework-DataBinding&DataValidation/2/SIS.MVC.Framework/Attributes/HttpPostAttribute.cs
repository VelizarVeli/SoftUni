namespace SIS.MVC.Framework.Attributes
{
    using HTTP.Enums;

    public class HttpPostAttribute : HttpAttribute
    {
        public HttpPostAttribute(string path)
            : base(path)
        {
        }

        public override HttpRequestMethod Method => HttpRequestMethod.Post;
    }
}