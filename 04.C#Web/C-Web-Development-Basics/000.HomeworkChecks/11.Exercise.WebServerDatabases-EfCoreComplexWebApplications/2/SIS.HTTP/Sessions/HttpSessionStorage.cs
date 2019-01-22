using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SIS.HTTP.Sessions
{
    public class HttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        public static readonly Dictionary<string, string> UserViewBag = new Dictionary<string, string>
        {
            ["Guest"] = "none",
            ["User"] =  "inline-block",
        };

        public static readonly Dictionary<string, string> GuestViewBag = new Dictionary<string, string>
        {
            ["Guest"] = "inline-block",
            ["User"] = "none",
        };

        private static readonly ConcurrentDictionary<string, IHttpSession> sessions 
            = new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string id)
        {
            return sessions.GetOrAdd(id, _ => new HttpSession(id));
        }
    }
}
