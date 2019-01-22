using System.Reflection;
using System.Text.RegularExpressions;
using SIS.Framework.Common;
using SIS.WebServer.Contracts;

namespace SIS.Framework
{
    public class MvcEngine
    {
	private readonly IServer server;

	public MvcEngine(IServer server)
	{
	    this.server = server;
	    RegisterAppData();
	    RegisterControllersData();
	    RegisterResourcesData();
	    RegisterViewsData();
	}

	public void Run()
	{
	    server.Run();
	}

	private void RegisterAppData()
	{
	    Assembly appAssembly = Assembly.GetEntryAssembly();
	    MvcContext.Get.AppName = appAssembly.GetName().Name;
	    Match appPathMatch = Regex.Match(
		appAssembly.EscapedCodeBase,
		Constants.AppPathPattern);
	    if (appPathMatch.Success)
	    {
		MvcContext.Get.AppPath = appPathMatch.Groups["appPath"].Value;
	    }
	}

	private void RegisterControllersData()
	{
	    MvcContext.Get.ControllersFolderName = "Controllers";
	    MvcContext.Get.ControllersSuffix = "Controller";
	}

	private void RegisterResourcesData()
	{
	    MvcContext.Get.ResourcesFolderName = "Resources";
	}

	private void RegisterViewsData()
	{
	    MvcContext.Get.DisplayTemplatesFolderName = "DisplayTemplates";
	    MvcContext.Get.DisplayTemplatesSuffix = "DisplayTemplate";
	    MvcContext.Get.ErrorViewName = "_Error";
	    MvcContext.Get.LayoutViewName = "_Layout";
	    MvcContext.Get.SharedViewsFolderName = "Shared";
	    MvcContext.Get.ViewsFolderName = "Views";
	    MvcContext.Get.ViewModelsFolderName = "ViewModels";
	}
    }
}
