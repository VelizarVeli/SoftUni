namespace SIS.Framework.Views
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ActionResults.Contracts;

    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;
        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, IDictionary<string, object> viewData)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.viewData = viewData;
        }

        private string ReadFile()
        {
            if (!File.Exists(this.fullyQualifiedTemplateName))
            {
                throw new FileNotFoundException();
            }

            var html = File.ReadAllText(this.fullyQualifiedTemplateName);
            return html;
        }

        public string Render()
        {
            var html = this.ReadFile();
            var renderHtml = this.RenderHtml(html);
            return renderHtml;
        }

        private string RenderHtml(string html)
        {
            var renderHtml = html;

            if (this.viewData.Any())
            {
                foreach (var pair in this.viewData)
                {
                    renderHtml = renderHtml.Replace($"{{{{{{{pair.Key}}}}}}}", pair.Value.ToString());
                }
            }

            return renderHtml;
        }
    }
}