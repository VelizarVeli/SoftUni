namespace SIS.Framework.Views
{
    using Framework.ActionResults;
    using System.IO;

    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;
        

        public View(string fullyQualifiedTemplateName)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
        }

        private string ReadFile(string fullyQualifiedTemplateName)
        {
            return File.ReadAllText(this.fullyQualifiedTemplateName);
        }

        public string Render()
        {
            var fullHtml = this.ReadFile(this.fullyQualifiedTemplateName);

            return fullHtml;
        }
    }
}
