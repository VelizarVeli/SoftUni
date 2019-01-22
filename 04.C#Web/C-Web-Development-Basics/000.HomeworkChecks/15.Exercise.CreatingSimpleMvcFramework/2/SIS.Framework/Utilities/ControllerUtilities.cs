namespace SIS.Framework.Utilities
{
    public static class ControllerUtilities
    {
        public static string GetControllerName(object controller)
        {
            return controller.GetType().Name.Replace(MvcContext.Get.ControllersSuffix, string.Empty);
        }

        public static string GetViewFullQualifiedName(string controller, string action)
        {
            return string.Format("../../../{0}/{1}/{2}.html", MvcContext.Get.ViewsFolder, controller, action);
        }
    }
}