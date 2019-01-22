using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework
{
    public class MvcContext
    {
        private static MvcContext Instance;

        public MvcContext()
        {
            
        }

        public static MvcContext Get => Instance == null ? (Instance = new MvcContext()) : Instance;

        public string AssemblyName { get; set; }

        public string ControllerSuffix { get; set; } = "Controller";

        public string ControllersFolder { get; set; } = "Controllers";

        public string ViewsFolderName { get; set; } = "Views";

        public string ModelsFolder { get; set; } = "Models";

        public string ResourceFolderName { get; set; } = "Resources";

        public string LayoutViewName { get; set; } = "_Layout";

        public string RootDirectoryRelativePath { get; set; } = "../../..";

        public string ViewsFolder { get; set; }
    }
}
