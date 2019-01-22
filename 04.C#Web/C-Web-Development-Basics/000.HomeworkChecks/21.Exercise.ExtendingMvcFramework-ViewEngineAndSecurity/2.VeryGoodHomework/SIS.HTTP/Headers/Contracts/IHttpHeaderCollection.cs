using System.Collections.Generic;

namespace SIS.HTTP.Headers.Contracts
{
    public interface IHttpHeaderCollection : IEnumerable<IHttpHeader>
    {
	void AddHeader(IHttpHeader header);
	bool ContainsHeader(string key);
	IHttpHeader GetHeader(string key);
	void SetHeader(IHttpHeader header);
    }
}
