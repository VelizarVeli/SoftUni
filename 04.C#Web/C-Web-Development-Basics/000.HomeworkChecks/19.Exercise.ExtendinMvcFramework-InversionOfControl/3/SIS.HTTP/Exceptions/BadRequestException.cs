using System;


namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("The Request was malformed or contains unsupported elements.")
        {

        }
    }

}
