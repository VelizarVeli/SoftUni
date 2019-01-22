namespace Eventures.Services.Contracts
{
    using System.Threading.Tasks;
    using Models;

    public interface IAccountService
    {
        Task<bool> Register(string username, string email, string password, string confirmPassword, string firstName, string lastName, string ucn);

        Task<bool> Login(string username, string password);

        Task<User> GetUser(string username);

        void Logout();
    }
}
