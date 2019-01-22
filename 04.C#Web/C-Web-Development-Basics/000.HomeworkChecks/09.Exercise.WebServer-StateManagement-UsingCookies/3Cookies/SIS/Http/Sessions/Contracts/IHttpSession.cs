using System;
using System.Collections.Generic;
using System.Text;

namespace Http.Sessions.Contracts
{
    public interface IHttpSession
    {
        string ID { get; }

        object GetParamether(string name);

        bool ContainsParamether(string naem);

        void AddParamether(string name, object paramether);

        void ClearParamether();
    }
}
