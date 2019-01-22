namespace SIS.Framework.Common
{
    public class Constants
    {
        public const string ViewDoesntExist = "There is no view at this path: {0}";

        public const string NotSupportedView = "The view result is not supported";

        public const string ControllerSuffix = "Controller";

        public const string DefaultControllerName = "Home";

        public const string DefaultActionName = "Index";

        public const string RootRelativePath = "../../../";

        public const string HtmlFileExtension = ".html";

        public static string[] ResourceExtentisons = { ".css", ".js" };

        public const string FolderViewsRelativePath = "../../../Views/";

        public const string LayoutViewName = "_Layout";

        public const string RenderBodyConstant = "@RenderBody";

        public const string HttpCookieKey = "Irunes_auth";
    }
}