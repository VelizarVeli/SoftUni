using System;
using SIS.HTTP.Enums;

namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        public const HttpResponseStatusCode StatusCode = HttpResponseStatusCode.BadRequest;

        public override string Message
        {
            get { return "The Request was malformed or contains unsupported elements."; }
        }
    }
}
