using System.ComponentModel;

namespace SIS.HTTP.Enumerations
{
    public enum HttpResponseStatusCode
    {
	[DisplayName("200 OK")]
	OK = 200,
	[DisplayName("201 Created")]
	Created = 201,
	[DisplayName("302 Found")]
	Found = 302,
	[DisplayName("303 See Other")]
	SeeOther = 303,
	[DisplayName("400 Bad Request")]
	BadRequest = 400,
	[DisplayName("401 Unauthorized")]
	Unauthorized = 401,
	[DisplayName("403 Forbidden")]
	Forbidden = 403,
	[DisplayName("404 Not Found")]
	NotFound = 404,
	[DisplayName("500 Internal Server Error")]
	InternalServerError = 500
    }
}
