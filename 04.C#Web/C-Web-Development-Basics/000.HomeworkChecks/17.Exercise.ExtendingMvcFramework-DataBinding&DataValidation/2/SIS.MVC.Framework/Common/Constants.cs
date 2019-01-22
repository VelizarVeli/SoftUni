namespace SIS.MVC.Framework.Common
{
    public class Constants
    {
        public const string ConnectionString = @"Server=.\SQLEXPRESS;Database=IRunes;Integrated Security=true;";

        public const string ControllerName = "Controller";

        public const string FolderViewsRelativePath = "../../../Views/";

        public const string HtmlFileExtension = ".html";

        public const string HttpCookieKey = "Irunes_auth";

        public const string ContentDisposition = "Content-Disposition";
        public const string ContentLength = "Content-Length";

        public const string RedirectHeaderKey = "Location";

        public const string TextHeaderKey = "Content-Type";
        public const string TextHeaderValue = "text/plain";

        public const string HtmlHeaderKey = "Content-Type";
        public const string HtmlHeaderValue = "text/html; charset=utf-8";

        public const string TypeNonInstanceable = "Type {0} cannot be instantiated";
    }
}