namespace SIS.HTTP.Sessions.Contracts
{
    public interface IHttpSessionStorage
    {
	void AddOrUpdateSession(IHttpSession session);
	IHttpSession GetOrAddSession(string id);
    }
}
