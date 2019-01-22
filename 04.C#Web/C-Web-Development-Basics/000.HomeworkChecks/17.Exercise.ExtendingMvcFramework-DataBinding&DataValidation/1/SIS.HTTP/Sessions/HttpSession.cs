namespace SIS.HTTP.Sessions
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class HttpSession : IHttpSession
    {
        private readonly Dictionary<string, object> parameters;

        public HttpSession(string id)
        {
            CoreValidator.ThrowIfNull(id, nameof(id));
            this.Id = id;
            this.parameters = new Dictionary<string, object>();
        }

        public string Id { get; }

        public void AddParameter(string name, object parameter)
        {
            CoreValidator.ThrowIfNullOrEmpty(name, nameof(name));
            CoreValidator.ThrowIfNull(parameter, nameof(parameter));

            this.parameters.Add(name, parameter);
        }

        public void ClearParameters()
            => this.parameters.Clear();

        public bool ContainsParameter(string name)
        {
            CoreValidator.ThrowIfNullOrEmpty(name, nameof(name));

            return this.parameters.ContainsKey(name);
        }

        public object GetParameter(string name)
        {
            CoreValidator.ThrowIfNull(name, nameof(name));
            return this.parameters.GetValueOrDefault(name, null);
        }
    }
}
