using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SIS.Framework.ActionResults;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, IDictionary<string, object> viewData)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.viewData = viewData;
        }

        private string ReadFile(string fullyQualifiedTemplateName)
        {
            if (!File.Exists(fullyQualifiedTemplateName))
            {
                throw new FileNotFoundException($"View does not exist at {fullyQualifiedTemplateName}");
            }
            return File.ReadAllText(fullyQualifiedTemplateName);
        }

        public string Render()
        {
            var fullHtml = this.ReadFile(this.fullyQualifiedTemplateName);
            string renderedHtml = this.RenderHtml(fullHtml);

            return fullHtml;
        }

        private string RenderHtml(string fullHtml)
        {
            string renderedHtml = fullHtml;

            if (this.viewData.Any())
            {
                foreach (var parameter in this.viewData)
                {
                    renderedHtml = renderedHtml.Replace($"{{{{{{{parameter.Key}}}}}}}", parameter.Value.ToString());
                }
            }

            return renderedHtml;
        }
    }
}
