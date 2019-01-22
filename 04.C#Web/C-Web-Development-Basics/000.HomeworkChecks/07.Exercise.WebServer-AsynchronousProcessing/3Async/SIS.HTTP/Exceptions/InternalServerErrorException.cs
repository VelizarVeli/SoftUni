using System;
using SIS.HTTP.Enums;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public const HttpResponseStatusCode StatusCode = HttpResponseStatusCode.InternalServerError;

        public override string Message
        {
            get { return "The server has encountered an error."; }
        }
    }
}
