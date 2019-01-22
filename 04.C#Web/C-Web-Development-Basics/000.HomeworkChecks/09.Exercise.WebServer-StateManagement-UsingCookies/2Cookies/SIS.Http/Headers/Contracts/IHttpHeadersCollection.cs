namespace SIS.Http.Headers.Contracts
{
    public interface IHttpHeadersCollection
    {
        void Add(HttpHeader header);

        bool ContainsHeader(string key);

        HttpHeader GetHeader(string key);
    }
}
