using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private const string InternalServerErrorExceptionMessage = "The Server has encountered an error.";

        public InternalServerErrorException() : this(InternalServerErrorExceptionMessage) { }

        public InternalServerErrorException(string message) : base(message) { }
    }
}
