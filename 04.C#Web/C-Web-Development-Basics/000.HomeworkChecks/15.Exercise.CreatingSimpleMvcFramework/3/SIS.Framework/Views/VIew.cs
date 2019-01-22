using SIS.Framework.ActionResults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        public View(string fullyQualifiedTemplateName)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
        }

        private string ReadFile(string fullyQualifiedTemplateName)
        {
            if (File.Exists(this.fullyQualifiedTemplateName))
            {
                return File.ReadAllText(this.fullyQualifiedTemplateName);
            }

            throw new FileNotFoundException("Could not find the required view.", this.fullyQualifiedTemplateName);
        }

        public string Render()
        {
            string fullHtml = this.ReadFile(this.fullyQualifiedTemplateName);
            return fullHtml;
        }
    }
}
