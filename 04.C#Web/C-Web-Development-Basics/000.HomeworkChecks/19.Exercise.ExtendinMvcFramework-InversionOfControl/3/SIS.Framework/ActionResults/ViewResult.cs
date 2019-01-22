using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.ActionResults
{
    class ViewResult : IViewable
    {
        public string Invoke() => this.View.Render();

        public ViewResult(IRenderable view)
        {
            this.View = view;
        }

        public IRenderable View { get; set; }
    }
}
