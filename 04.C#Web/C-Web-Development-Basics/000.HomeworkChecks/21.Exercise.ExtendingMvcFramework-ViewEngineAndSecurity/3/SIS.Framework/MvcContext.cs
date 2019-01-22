namespace SIS.Framework
{
    public class MvcContext
    {
        private static MvcContext Instance;

        public MvcContext() {}

        public static MvcContext Get => Instance == null ? (Instance = new MvcContext()) : Instance;

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }

        public string ResourceFolderName { get; set; } = "Resources";

        public string LayoutViewName { get; set; } = "_Layout";

        public string SharedViewsFolderName { get; set; } = "Shared";

        public string RootDirectoryRelativePath { get; set; } = "../../..";

        public string ViewFolderFullPath => "../../../Views";

        public string ErrorViewFolder => "Error";

        public string HtmlFileExtention => "html";
    }
}