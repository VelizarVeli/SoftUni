namespace WebServer.IRunesApplication.Services.Contracts
{
    using ViewModels.Account;

    public interface IUserService
    {
        bool Create(string username, string password, string email);

        bool Find(string username, string password);

        ProfileViewModel Profile(string username);

        int? GetUserId(string username);
    }
}
