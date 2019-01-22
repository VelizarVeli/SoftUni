using System;
using System.Net;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private const string ErrorMessage = "The Server has encountered an error.";

        public const HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;

        public InternalServerErrorException()
        :base(ErrorMessage)
        {
            
        }
    }
}
