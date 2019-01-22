namespace SIS.HTTP.Exceptions
{
    using System;
    using Common;

    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base(GlobalConstans.BadRequestMessage)
        {
        }
    }
}