using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.ActionResults
{
    public class RedirectResult : IRedirectable
    {
        public string Invoke() => this.RedirectUrl;

        public RedirectResult(string redirectUrl)
        {
            this.RedirectUrl = redirectUrl;
        }

        public string RedirectUrl { get; }
    }
}
