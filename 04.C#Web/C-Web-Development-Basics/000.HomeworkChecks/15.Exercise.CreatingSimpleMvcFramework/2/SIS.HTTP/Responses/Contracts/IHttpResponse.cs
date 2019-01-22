namespace SIS.HTTP.Responses.Contracts
{
    using Cookies;
    using Cookies.Contracts;
    using Enums;
    using Headers;
    using Headers.Contracts;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        byte[] Content { get; set; }

        IHttpCookieCollection Cookies { get; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();

        void AddCookie(HttpCookie cookie);
    }
}