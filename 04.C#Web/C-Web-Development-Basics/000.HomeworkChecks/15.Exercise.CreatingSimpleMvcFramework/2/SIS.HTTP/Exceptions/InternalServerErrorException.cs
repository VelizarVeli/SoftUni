namespace SIS.HTTP.Exceptions
{
    using System;
    using Common;

    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException()
            : base(GlobalConstans.InternalServerErrorMessage)
        {
        }
    }
}