namespace SIS.HTTP.Exceptions
{
    using System;

    public class InternalServerErrorException : Exception
    {
        //public const string DefaultMessage = "The Server has encountered an error.";

        //public InternalServerErrorException()
        //    : base(DefaultMessage)
        //{
        //}

        public override string Message => "The Server has encountered an error.";
    }
}
