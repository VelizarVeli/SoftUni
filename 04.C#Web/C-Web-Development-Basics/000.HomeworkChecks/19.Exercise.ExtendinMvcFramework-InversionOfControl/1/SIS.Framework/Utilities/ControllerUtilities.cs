namespace SIS.Framework.Utilities
{
    using Common;
    using System;

    public class ControllerUtilities
    {
        public static string GetControllerName(object controller) =>
            controller.GetType().Name.Replace(MvcContext.Get.ControllerSuffix, string.Empty);

        public static string GetViewPath(string controllerName, string viewName) =>
            String.Format($"{Constants.RootRelativePath}{MvcContext.Get.ViewsFolder}\\{controllerName}\\{viewName}{Constants.HtmlFileExtension}");
    }
}