namespace SIS.HTTP.Exceptions
{
    using Common;
    using System;

    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException()
            : base(Messages.InternalServerErrorDefaultMessage)
        {
        }

        public InternalServerErrorException(Exception innerException)
            : base(Messages.InternalServerErrorDefaultMessage, innerException)
        {
        }
    }
}