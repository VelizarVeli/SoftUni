namespace SIS.Framework
{
    public class MvcContext
    {
	private static MvcContext Instance;

	private MvcContext() { }

	public static MvcContext Get => Instance ?? (Instance = new MvcContext());

	public string AppName { get; set; }
	public string AppPath { get; set; }
	public string ControllersFolderName { get; set; }
	public string ControllersSuffix { get; set; }
	public string DisplayTemplatesFolderName { get; set; }
	public string DisplayTemplatesSuffix { get; set; }
	public string ErrorViewName { get; set; }
	public string LayoutViewName { get; set; }
	public string ResourcesFolderName { get; set; }
	public string SharedViewsFolderName { get; set; }
	public string ViewsFolderName { get; set; }
	public string ViewModelsFolderName { get; set; }
    }
}
