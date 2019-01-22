using System;
using System.Collections;
using System.Collections.Generic;


namespace SIS.Http.Sessions
{
    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> parameters;

        public HttpSession(string id)
        {
            this.Id = id;
            this.parameters = new Dictionary<string, object>();
        }

        public string Id { get; }

        public object GetParameter(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException();
            }

            if (!this.ContainsParameter(key))
            {
                return null;
            }

            return this.parameters[key];
        }

        public void AddParameter(string name, object parameter)
        {
            if (!this.ContainsParameter(name))
            {
                throw new ArgumentException();
            }

            this.parameters[name] = parameter;
        }

        public bool ContainsParameter(string key)
        {
            return this.parameters.ContainsKey(key);
        }

        public void ClearParameters()
        {
            this.parameters.Clear();
        }
    }
}
