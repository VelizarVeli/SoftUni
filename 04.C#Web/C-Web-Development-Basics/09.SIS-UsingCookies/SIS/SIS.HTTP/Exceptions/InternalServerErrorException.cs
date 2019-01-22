using System;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public const string ExceptionMessage = "The Server has encountered an error.";

        public InternalServerErrorException()
            : base(ExceptionMessage)
        { }
    }
}