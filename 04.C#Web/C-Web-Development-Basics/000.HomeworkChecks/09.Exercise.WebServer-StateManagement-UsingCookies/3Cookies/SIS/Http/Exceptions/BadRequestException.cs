using System;
using System.Net;

namespace Http.Exceptions
{
    public class BadRequestException : Exception
    {
        private const string ExeptionMessage = "The Request was malformed or contains unsupported elements.";
        public const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;

        public BadRequestException()
            :base(ExeptionMessage)
        {

        }
    }
}
