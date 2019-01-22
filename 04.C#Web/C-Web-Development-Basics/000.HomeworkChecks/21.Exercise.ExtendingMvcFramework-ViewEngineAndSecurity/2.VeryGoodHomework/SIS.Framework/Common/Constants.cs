namespace SIS.Framework.Common
{
    public static class Constants
    {
	public const string AppPathPattern = @"(?:.+)(?<appPath>[A-Z]\:.+)(?:\/bin\/.+)";
	public const string BadRequestResultMessage = "<h1 style='color: orangered'>Bad request: {0}.</h1>";
	public const string DefaultActionName = "Index";
	public const string DefaultControllerName = "Home";
	public const string ErrorKey = "Error";
	public const string FolderSeparator = "/";
	public const string HtmlBodyPlaceholder = "@RenderBody";
	public const string HtmlErrorPlaceholder = "@RenderError";
	public const string HtmlErrorMessagePlaceholder = "@ErrorMessage";
	public const string HtmlFileExtension = ".html";
	public const string IdentityKey = "Identity";
	public const string ItemPlaceholder = "@Item";
	public const string IsAuthenticatedKey = "IsAuthenticated";
	public const string ModelCollectionPattern = @"\@Model\.Collection\.(?<collection>\w+)\((?<item>.+)\)";
	public const string ModelPlaceholder = "@Model";
	public const string NotFoundResultMessage = "<h1 style='color: orangered'>{0} '{1}' not found.</h1>";
	public const string PageTitleKey = "PageTitle";
	public const string ResourcePattern = @".*\/(?<fileName>[^\/]+[\.](?<fileType>[a-zA-z0-9]+))";
	public const int ServerHostPort = 8000;
	public const string ViewNotFoundMessage = "{0}View could not be found{1}.";
    }
}
