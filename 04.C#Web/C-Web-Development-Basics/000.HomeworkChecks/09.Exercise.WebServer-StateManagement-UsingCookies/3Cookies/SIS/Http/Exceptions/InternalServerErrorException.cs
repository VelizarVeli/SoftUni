using System;
using System.Net;

namespace Http.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private const string ExeptionMessage = "The Server has encountered an error.";
        public const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;

        public InternalServerErrorException()
            : base(ExeptionMessage)
        {

        }
    }
}
