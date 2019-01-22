namespace SIS.HTTP.Sessions
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> parameters;

        public HttpSession(string id)
        {
            this.Id = id;
            this.parameters = new Dictionary<string, object>();
        }

        public string Id { get; }

        public void AddParameter(string name, object parameter)
        {
            if (parameter != null && !this.ContainsParameter(name)
                               && !string.IsNullOrEmpty(name))
            {
                this.parameters[name] = parameter;
            }
        }

        public void ClearParameters()
        {
            if (this.parameters.Any())
            {
                this.parameters.Clear();
            }
        }

        public bool ContainsParameter(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(Messages.CannotBeNullExceptionMessage, nameof(name));
            }

            return this.parameters.ContainsKey(name);
        }

        public object GetParameter(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(Messages.CannotBeNullExceptionMessage, nameof(name));
            }

            if (!this.ContainsParameter(name))
            {
                return null;
            }

            return this.parameters[name];
        }
    }
}