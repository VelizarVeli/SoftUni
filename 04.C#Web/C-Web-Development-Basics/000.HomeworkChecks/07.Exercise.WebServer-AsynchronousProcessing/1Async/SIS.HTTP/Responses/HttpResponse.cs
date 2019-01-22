namespace SIS.HTTP.Responses
{
    using Contracts;
    using Enums;
    using Headers;
    using Headers.Contracts;
    using SIS.HTTP.Common;
    using Extensions;

    using System.Text;
    using System;
    using System.Linq;

    public class HttpResponse : IHttpResponse
    {
        private const string HeaderNullMessage = "Header cannot be null!";
        public HttpResponse() { }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            if (header == null)
            {
                throw new ArgumentException(HeaderNullMessage);
            }

            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
              .Append(Environment.NewLine)
              .Append(this.Headers)
              .Append(Environment.NewLine)
              .Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}