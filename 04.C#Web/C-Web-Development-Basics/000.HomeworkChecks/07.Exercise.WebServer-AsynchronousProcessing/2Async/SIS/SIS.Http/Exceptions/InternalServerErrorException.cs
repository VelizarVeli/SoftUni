using System;
using System.Net;

namespace SIS.Http.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private const string ErrorMessage = "The Server has encountered an error.";

        public const HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;

        //public override string Message => "Error";// ili prez costructora s default nessage ot private poleto

        public InternalServerErrorException()
            :base(ErrorMessage)
        {

        }
    }
}
