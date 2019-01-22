using System;

namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        public const string ExceptionMessage = "The Request was malformed or contains unsupported elements.";

        public BadRequestException()
            : base(ExceptionMessage)
        { }
    }
}