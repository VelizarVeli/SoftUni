using SIS.Framework.Api.Contracts;
using SIS.Services.Contracts;

namespace SIS.Framework.Api
{
    public abstract class MvcApplication : IMvcApplication
    {
	public virtual void Configure() { }

	public virtual void ConfigureServices(IServiceCollection serviceCollection) { }
    }
}
