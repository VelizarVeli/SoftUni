namespace SIS.Framework.Views
{
    using ActionResults.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class View : IRenderable
    {
        private const string DefaulPath = @"../../../";
        private const string HtmlExtension = ".html";

        private readonly string fullyQualifiedTemplateName;

        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, IDictionary<string, object> viewData)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.viewData = viewData;
        }

        public string Render()
        {
            string fullHtml = this.ReadFile(this.fullyQualifiedTemplateName);
            string renderedHtml = this.RenderHtml(fullHtml);

            return renderedHtml;
        }

        private string ReadFile(string fullyQualifiedTemplateName)
        {
            fullyQualifiedTemplateName = DefaulPath + fullyQualifiedTemplateName + HtmlExtension;

            if (!File.Exists(fullyQualifiedTemplateName)) throw new FileNotFoundException();

            return File.ReadAllText(fullyQualifiedTemplateName);
        }

        private string RenderHtml(string fullHtml)
        {
            string renderedHtml = fullHtml;

            if (this.viewData.Any())
            {
                foreach(KeyValuePair<string, object> parameter in this.viewData)
                {
                    renderedHtml = renderedHtml
                        .Replace($"{{{{{{{parameter.Key}}}}}}}", 
                            parameter.Value.ToString());
                }
            }

            return renderedHtml;
        }
    }
}
