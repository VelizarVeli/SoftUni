using SIS.Framework.ActionResults.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        private readonly string fullyQualifiedLayoutName;

        private readonly bool isLoggedIn;

        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, string fullyQualifiedLayoutName, IDictionary<string, object> viewData, bool isLoggedIn)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.fullyQualifiedLayoutName = fullyQualifiedLayoutName;
            this.isLoggedIn = isLoggedIn;
            this.viewData = viewData;
        }

        private string ReadFile(string fullQualifiedNameTemplateName)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;

            char separator = (char)47;

            var parts = codeBase.Remove(0, 8)
                .Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .Skip(4)
                .Reverse();

            string rootPath = string.Join("\\", parts);

            string filePath = rootPath + "\\" + fullQualifiedNameTemplateName;

           //var a =  File.ReadAllText(fullQualifiedNameTemplateName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"View does not exist at {fullQualifiedNameTemplateName}");
            }

            return File.ReadAllText(fullQualifiedNameTemplateName);
        }

        public string Render()
        {
            var layout = this.ReadFile(this.fullyQualifiedLayoutName);
            var fullHtml = this.ReadFile(this.fullyQualifiedTemplateName);
            var allContent = layout.Replace("@RenderBody()", fullHtml);
            var renderedHtml = this.RenderHtml(allContent);

            return renderedHtml;
        }

        private string RenderHtml(string fullHtml)
        {
            fullHtml = fullHtml.Replace("@Model.Navigation", this.GetNavigation());

            if (this.viewData.Any())
            {
                foreach (var item in this.viewData)
                {
                    fullHtml = fullHtml.Replace("@Model." + item.Key, item.Value.ToString());
                }
            }

            return fullHtml;
        }

        private string GetNavigation()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;

            char separator = (char)47;

            var parts = codeBase.Remove(0, 8)
                .Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .Skip(4)
                .Reverse();

            string rootPath = string.Join("\\", parts);

          //  string filePath = rootPath + "\\" + fullQualifiedNameTemplateName;

            var fileName = this.isLoggedIn
                               ? "NavigationLoggedIn"
                               : "NavigationLoggedOut";

            string result = File.ReadAllText($"{rootPath}\\{MvcContext.Get.ViewsFolder}\\Navigation\\{fileName}.html");
            return result;
        }
    }
}
