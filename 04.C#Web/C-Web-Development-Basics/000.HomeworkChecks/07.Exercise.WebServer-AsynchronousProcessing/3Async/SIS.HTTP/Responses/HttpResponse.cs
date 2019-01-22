using System;
using System.Linq;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace SIS.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse() { }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            Headers = new HttpHeaderCollection();
            Content = new byte[0];
            StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }
        public IHttpHeaderCollection Headers { get; private set; }
        public byte[] Content { get; set; }
        public void AddHeader(HttpHeader header)
        {
            Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            var responseValue = Encoding.UTF8.GetBytes(this.ToString());

            return responseValue.Concat(Content).ToArray();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {StatusCode.GetResponseLine()}")
                .AppendLine(Headers.ToString())
                .AppendLine();

            return sb.ToString();
        }
    }
}
