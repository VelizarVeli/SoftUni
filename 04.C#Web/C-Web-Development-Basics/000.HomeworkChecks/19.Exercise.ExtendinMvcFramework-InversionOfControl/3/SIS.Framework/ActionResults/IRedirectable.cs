using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.ActionResults
{
    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get; }
    }
}
