using System;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException(string message = "The Server has encountered an error.") 
            : base(message)
        {
        }
    }
}