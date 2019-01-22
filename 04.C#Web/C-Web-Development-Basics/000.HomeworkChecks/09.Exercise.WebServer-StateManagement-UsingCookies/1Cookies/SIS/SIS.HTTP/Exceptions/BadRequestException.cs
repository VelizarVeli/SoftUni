using System;

namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message = "The Request was malformed or contains unsupported elements.") 
            : base(message)
        {
        }
    }
}