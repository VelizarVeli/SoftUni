using System.Dynamic;
using System.Net;
using SIS.Http.Headers;
using SIS.Http.Headers.Contracts;

namespace SIS.Http.Responses.Contracts
{
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        IHttpHeadersCollection Headers { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();
    }
}