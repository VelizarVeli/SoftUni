namespace IRunesWebApp.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.WebServer.Results;
    using System.IO;
    using System.Runtime.CompilerServices;
    using SIS.HTTP.Enums;
    using IRunesWebApp.Data;

    public abstract class BaseController
    {
        private const string RootDirectoryRelativePath = "../../../";

        private const string ControllerDefaultName = "Controller";

        private const string ViewsFolderName = "Views";

        private const string DirectorySeparator = "/";

        private const string HtmlFileExtension = ".html";

        public BaseController()
        {
            this.Context = new IRunnesContext();
        }

        protected IRunnesContext Context { get; set; }

        private string GetCurrentControllerName() =>
            this.GetType().Name.Replace(ControllerDefaultName, string.Empty);

        protected IHttpResponse View([CallerMemberName] string viewName = "")
        {
            string filePath = RootDirectoryRelativePath +
                               ViewsFolderName +
                               DirectorySeparator +
                               this.GetCurrentControllerName() +
                               DirectorySeparator +
                               viewName +
                               HtmlFileExtension;
            if (!File.Exists(filePath))
            {
                return new BadRequestResult($"View {viewName} not found.", HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllText(filePath);

            var response = new HtmlResult(fileContent, HttpResponseStatusCode.Ok);

            return response;
        }
    }
}
