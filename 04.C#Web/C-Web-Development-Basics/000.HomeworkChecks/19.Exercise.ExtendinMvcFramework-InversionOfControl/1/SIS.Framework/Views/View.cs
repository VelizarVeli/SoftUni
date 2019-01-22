namespace SIS.Framework.Views
{
    using ActionResults.Contracts;
    using Common;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class View : IRenderable
    {
        private readonly string templatePath;

        private readonly IDictionary<string, object> viewData;

        public View(string templatePath, IDictionary<string, object> viewData)
        {
            this.templatePath = templatePath;
            this.viewData = viewData;
        }

        private string ReadFile()
        {
            if (!File.Exists(this.templatePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ViewDoesntExist, this.templatePath));
            }

            return File.ReadAllText(this.templatePath);
        }

        public string Render()
        {
            var fullHtml = this.ReadFile();
            var renderedHtml = this.RednderHtml(fullHtml);

            //var layoutWithView = this.AddViewToLayout(renderedHtml);

            return renderedHtml;
        }

        private object AddViewToLayout(string renderedHtml)
        {
            var layoutViewPath = Constants.FolderViewsRelativePath
                           + Constants.LayoutViewName
                           + Constants.HtmlFileExtension;
            if (!File.Exists(layoutViewPath))
            {
                throw new FileNotFoundException(string.Format(Messages.ViewDoesNotExists, layoutViewPath));
            }

            var layoutViewContent = File.ReadAllText(layoutViewPath);

            return layoutViewContent.Replace(Constants.RenderBodyConstant, renderedHtml);
        }

        private string RednderHtml(string fullHtml)
        {
            if (this.viewData.Any())
            {
                foreach (var param in this.viewData)
                {
                    fullHtml = fullHtml.Replace($"{{{{{param.Key}}}}}", param.Value.ToString());
                }
            }

            return fullHtml;
        }
    }
}