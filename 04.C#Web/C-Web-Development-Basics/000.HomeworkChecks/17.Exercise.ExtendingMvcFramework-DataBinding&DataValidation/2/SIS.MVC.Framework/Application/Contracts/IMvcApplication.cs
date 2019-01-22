namespace SIS.MVC.Framework.Application.Contracts
{
    using Services.Contracts;

    public interface IMvcApplication
    {
        void ConfigureServices(IServiceCollection collection);
    }
}