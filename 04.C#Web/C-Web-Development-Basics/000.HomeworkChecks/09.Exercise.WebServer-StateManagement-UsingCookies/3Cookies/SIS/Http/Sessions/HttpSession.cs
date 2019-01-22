using Http.Sessions.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Http.Sessions
{
    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> paramethers;

        public HttpSession(string id)
        {
            this.ID = id;
            this.paramethers = new Dictionary<string, object>();
        }


        public string ID { get; }

        public void AddParamether(string name, object paramether)
        {
            if (ContainsParamether(name))
            {
                throw new ArgumentException();
            }
            this.paramethers[name] = paramether;
        }

        public void ClearParamether()
        {
            this.paramethers.Clear();
        }

        public bool ContainsParamether(string key)
        {
            return this.paramethers.ContainsKey(key);
        }

        public object GetParamether(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException();
            }
            if (!this.ContainsParamether(key))
            {
                return null;
            }
            return this.paramethers[key];
        }
    }
}
