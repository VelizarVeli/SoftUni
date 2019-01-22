namespace SIS.HTTP.Common
{
    public static class Constants
    {
	public const int CookieDefaultLifetimeInDays = 3;
	public const int CookieDefaultMaxAgeInSeconds = 259200;
	public const string CookieDefaultPath = "/";
	public const string CookieRequestHeaderKey = "Cookie";
	public const string CookieResponseHeaderKey = "Set-Cookie";
	public const string ContentDispositionHeaderKey = "Content-Disposition";
	public const string ContentLengthHeaderKey = "Content-Length";
	public const string ContentTypeHeaderKey = "Content-Type";
	public const string ContentTypeHtmlHeaderValue = "text/html; charset=utf-8";
	public const string ContentTypeTextHeaderValue = "text/plain; charset=utf-8";
	public const string ExpiresCookieKey = "Expires";
	public const string HostHeaderKey = "Host";
	public const string HttpOneProtocolFragment = "HTTP/1.1";
	public const string HttpOnlyCookieKey = "HttpOnly";
	public const string LocationHeaderKey = "Location";
	public const string MaxAgeCookieKey = "Max-Age";
	public const string NotFoundMessage =
	    "<h1 style='color: orangered'>The resource you are looking for is not available.</h1>";
	public const string PathCookieKey = "Path";
	public const int SecondsInDay = 86400;
	public const string SessionCookieKey = "SIS-SesId";
	public const string UnauthenticatedMessage =
	    "<h1 style='color: orangered'>You must be logged in to use this functionality!</h1>";
	public const string UnauthorizedMessage =
	    "<h1 style='color: orangered'>You do not have sufficient privileges to use this functionality!</h1>";
	public const string UrlPattern = @"^(?<path>\/[^?#\r\n]*)(?<query>\?[^?#\r\n]*)?(?<fragment>\#[^?#\r\n]+$)?";
    }
}
