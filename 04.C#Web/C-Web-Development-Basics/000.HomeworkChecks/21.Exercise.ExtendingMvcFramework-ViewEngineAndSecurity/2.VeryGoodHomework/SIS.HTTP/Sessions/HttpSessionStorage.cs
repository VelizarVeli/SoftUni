using System.Collections.Concurrent;
using SIS.HTTP.Sessions.Contracts;

namespace SIS.HTTP.Sessions
{
    public class HttpSessionStorage : IHttpSessionStorage
    {
	private readonly ConcurrentDictionary<string, IHttpSession> sessions;

	public HttpSessionStorage()
	{
	    sessions = new ConcurrentDictionary<string, IHttpSession>();
	}

	public void AddOrUpdateSession(IHttpSession session)
	{
	    sessions.AddOrUpdate(session.Id, session, (k, v) => v = session);
	}

	public IHttpSession GetOrAddSession(string sessionId)
	{
	    return sessions.GetOrAdd(sessionId, session => new HttpSession(sessionId));
	}
    }
}
