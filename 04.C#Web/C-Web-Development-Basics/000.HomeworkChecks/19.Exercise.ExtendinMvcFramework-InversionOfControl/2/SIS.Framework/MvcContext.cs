using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework
{
    public class MvcContext
    {
        private static MvcContext instance;

        private MvcContext() { }

        public static MvcContext Get => instance ?? (instance = new MvcContext());

        public string AssemblyName { get; set; }

        public string ControllerSuffix { get; set; } = "Controller";

        public string ViewsFolder { get; set; } = "Views";

        public string ControllersFolder { get; set; } = "Controllers";

        public string ModelsFolder { get; set; } = "Models";
    }
}
