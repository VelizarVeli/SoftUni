namespace SIS.HTTP.Sessions
{
    using System.Collections.Generic;
    using Common;
    using Contracts;

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

        public object GetParameter(string name)
        {
            CoreValidator.ThrowIfNullOrEmpty(name, nameof(name));

            return this.parameters[name];
        }

        public bool ContainsParameter(string name)
        {
            CoreValidator.ThrowIfNullOrEmpty(name, nameof(name));

            return this.parameters.ContainsKey(name);
        }

        public void AddParameter(string name, object parameter)
        {
            CoreValidator.ThrowIfNullOrEmpty(name, nameof(name));
            CoreValidator.ThrowIfNull(parameter, nameof(parameter));

            this.parameters[name] = parameter;
        }

        public void ClearParameters()
        {
            this.parameters.Clear();
        }
    }
}