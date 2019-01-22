namespace SIS.WebServer.Common
{
    public class Constants
    {
        public const string ResponseHttpOnly = "HttpOnly";

        public const string SessionCookieKey = "SIS_ID";

        public const string DefaultErrorHeading = "<h1>Error occured, see details</h1>";

        public static string[] ResourceExtentisons = { ".css", ".js" };
        public const string FolderResourcesRelativePath = "../../../Resources/";

        public const string ContentDisposition = "Content-Disposition";
        public const string ContentLength = "Content-Length";

        public const string HtmlHeaderKey = "Content-Type";
        public const string HtmlHeaderValue = "text/html; charset=utf-8";
    }
}