using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Sessions
{
    public static class HttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        private static readonly ConcurrentDictionary<string, IHttpSession> sessions
            = new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string id)
        {
            return sessions.GetOrAdd(id, s => new HttpSession(id));
        }
    }
}
