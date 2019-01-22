using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.ActionResults
{
    public interface IViewable : IActionResult
    {
        IRenderable View { get; set; }
    }
}
