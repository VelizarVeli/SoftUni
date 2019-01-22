using System.Linq;
using System.Net;
using System.Text;
using SIS.Http.Common;
using SIS.Http.Extension;
using SIS.Http.Headers;
using SIS.Http.Headers.Contracts;
using SIS.Http.Responses.Contracts;

namespace SIS.Http.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse() {}

        public HttpResponse(
            HttpStatusCode statusCode)
        {
            Headers = new HttpHeadersCollection();
            Content = new byte[0];
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }

        public IHttpHeadersCollection Headers { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            //ve`e sme naprawili prowerka v request i za towa ne prowerqwame tuk
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .AppendLine($"{this.Headers}")
                .AppendLine();

            return result.ToString();
        }
    }
}