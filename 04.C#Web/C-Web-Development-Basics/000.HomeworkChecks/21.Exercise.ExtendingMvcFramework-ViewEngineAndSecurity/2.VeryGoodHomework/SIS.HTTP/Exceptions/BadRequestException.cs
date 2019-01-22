using System;
using System.Net;

namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
	public const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;

	public override string Message => "The Request was malformed or contains unsupported elements.";
    }
}
