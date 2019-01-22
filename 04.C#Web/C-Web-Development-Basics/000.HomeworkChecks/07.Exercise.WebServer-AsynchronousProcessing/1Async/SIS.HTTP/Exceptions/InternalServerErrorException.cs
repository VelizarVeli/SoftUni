namespace SIS.HTTP.Exceptions
{
    using System;

    public class InternalServerErrorException : Exception
    {
        public override string Message => "The Server has encountered an error.";
    }
}
