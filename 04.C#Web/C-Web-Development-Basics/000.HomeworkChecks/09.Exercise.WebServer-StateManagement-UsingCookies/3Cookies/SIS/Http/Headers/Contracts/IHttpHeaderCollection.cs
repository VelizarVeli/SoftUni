namespace Http.Headers.Contracts
{
    public interface IHttpHeaderCollection
    {
        void Add(HttpHeader header);

        bool ContainsHeader(string key);

        HttpHeader GetgHeader(string key);
    }
}
