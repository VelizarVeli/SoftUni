using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP
{
    public class BadRequestException : Exception
    {
        private const string BadRequestMessage = "The Request is malformed.";

        public BadRequestException() : this(BadRequestMessage) { }

        public BadRequestException(string message) : base(message) { }
    }
}
