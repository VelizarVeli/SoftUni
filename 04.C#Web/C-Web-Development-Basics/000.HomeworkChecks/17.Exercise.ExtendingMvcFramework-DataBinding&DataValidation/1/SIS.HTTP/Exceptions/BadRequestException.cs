namespace SIS.HTTP.Exceptions
{
    using System; 

    public class BadRequestException : Exception
    {
        //public const string DefaultMessage = "The Request was malformed or contains unsupported elements.";

        //public BadRequestException()
        //    : base(DefaultMessage)
        //{
        //}

        public override string Message => "The Request was malformed or contains unsupported elements.";
    }
}
