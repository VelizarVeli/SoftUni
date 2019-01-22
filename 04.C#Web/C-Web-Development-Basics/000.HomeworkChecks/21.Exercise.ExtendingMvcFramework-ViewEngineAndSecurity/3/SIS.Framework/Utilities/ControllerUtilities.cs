namespace SIS.Framework.Utilities
{
    public class ControllerUtilities
    {
        public static string GetControllerName(object controller) => 
            controller.GetType().Name.Replace(MvcContext.Get.ControllersSuffix, string.Empty);
        
        public static string GetFullQualifiedName(string controller, string action) =>
            $"{MvcContext.Get.ViewFolderFullPath}/{controller}/{action}.{MvcContext.Get.HtmlFileExtention}";
    }
}