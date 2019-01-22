using System;
using System.Net;
using SIS.Http.Enum;

namespace SIS.Http.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private const string ErrorMessage = "The Server has encountered an error.";

        public const HttpResponseStatusCode StatusCode = HttpResponseStatusCode.InternalServerError;

        public InternalServerErrorException()
            : base(ErrorMessage)
        {

        }
    }
}
