namespace SIS.HTTP.Exceptions
{
    using Common;
    using System;

    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base(Messages.BadRequestDefaultMessage)
        {
        }
    }
}