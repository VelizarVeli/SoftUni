
using System;
using System.Net;

namespace SIS.Http.Exceptions
{
    public class BadRequestException : Exception
    {
        private const string ErrorMessage = "The Request was malformed or contains unsupported elements.";

        public const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;

        //public override string Message => "Error";// ili prez costructora s default nessage ot private poleto

        public BadRequestException()
            :base(ErrorMessage)
        {

        }
    }
}
