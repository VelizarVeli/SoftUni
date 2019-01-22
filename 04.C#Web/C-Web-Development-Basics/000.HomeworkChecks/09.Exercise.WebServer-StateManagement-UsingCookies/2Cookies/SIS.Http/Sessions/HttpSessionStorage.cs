using System.Collections.Concurrent;

namespace SIS.Http.Sessions
{
    public class HttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        private static ConcurrentDictionary<string, IHttpSession> sessions =>
            new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string id)
        {
            return  sessions.GetOrAdd(id, _ => new HttpSession(id));
        }


    }
}
