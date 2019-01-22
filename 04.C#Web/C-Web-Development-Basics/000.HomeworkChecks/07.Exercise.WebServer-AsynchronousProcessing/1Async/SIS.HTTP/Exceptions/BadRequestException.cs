namespace SIS.HTTP.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        public override string Message => "The Request was malformed or contains unsupported elements.";
    }
}
