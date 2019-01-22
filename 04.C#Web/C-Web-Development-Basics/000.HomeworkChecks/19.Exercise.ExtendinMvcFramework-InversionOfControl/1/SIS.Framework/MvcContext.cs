namespace SIS.Framework
{
    using System.Reflection;

    public class MvcContext
    {
        private static MvcContext Instance;

        public MvcContext()
        {
        }

        public static MvcContext Get => Instance == null ? (Instance = new MvcContext()) : Instance;

        public AssemblyName AssemblyName { get; set; }

        public string ControllerSuffix { get; set; } = "Controller";

        public string ControllersFolder { get; set; } = "Controllers";

        public string ViewsFolder { get; set; } = "Views";

        public string ModelsFolder { get; set; } = "Mdodels";
    }
}