using System;
using System.Net;
using SIS.Http.Enum;

namespace SIS.Http.Exceptions
{
    public class BadRequestException : Exception
    {
        private  const  string  ErrorMessage= "The Request was malformed or contains unsupported elements.";

        public HttpResponseStatusCode StatusCode = HttpResponseStatusCode.BadRequest;

        public BadRequestException()
            : base(ErrorMessage)
        {
        }
    }
}