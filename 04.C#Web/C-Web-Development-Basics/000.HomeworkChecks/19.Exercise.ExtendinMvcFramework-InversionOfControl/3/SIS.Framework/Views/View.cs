using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SIS.Framework.ActionResults;
using SIS.HTTP.Common;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private const string RenderBodyConstant = "@RenderBody()";

        public const string NavigationModelConstant = "@Model.Navigation";

        private const string NavigationLoggedInDirectory = "../../../Navigation/NavigationLoggedIn.html";

        private const string NavigationLoggedOutDirectory = "../../../Navigation/NavigationLoggedOut.html";

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
                throw new FileNotFoundException($"View does not exist at {fullyQualifiedTemplateName}");
            }
            return File.ReadAllText(fullyQualifiedTemplateName);
        }

        public string Render()
        {
            var fullHtml = this.ReadFile();
            var renderedHtml = this.RenderHtml(fullHtml);

            var layoutWithView = this.AddViewToLayout(renderedHtml);

            return layoutWithView;
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

        private bool IsAuthenticated()
        {
            return this.viewData.ContainsKey("username");
        }

        private string AddViewToLayout(string renderedHtml)
        {
            var layoutViewPath = MvcContext.Get.RootDirectoryRelativePath +
                                 GlobalConstants.DirectorySeparator +
                                 MvcContext.Get.ViewsFolderName +
                                 GlobalConstants.DirectorySeparator +
                                 MvcContext.Get.LayoutViewName +
                                 GlobalConstants.HtmlFileExtension;

            if (!File.Exists(layoutViewPath))
            {
                throw new FileNotFoundException($"View does not exist at {fullyQualifiedTemplateName}");
            }

            var layoutViewContent = File.ReadAllText(layoutViewPath);
            var layoutWithView = layoutViewContent.Replace(RenderBodyConstant, renderedHtml);


            
            if(IsAuthenticated())
            {
                layoutWithView = layoutWithView.Replace(NavigationModelConstant, File.ReadAllText(NavigationLoggedInDirectory));
            }
            else
            {
                layoutWithView = layoutWithView.Replace(NavigationModelConstant, File.ReadAllText(NavigationLoggedOutDirectory));
            }

            return layoutWithView;

        }
    }
}
