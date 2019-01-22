using System.Threading.Tasks;

namespace Eventures.Services.Contracts
{
    public interface IUsersService
    {
        Task<bool> Register(string username,
            string password,
            string confirmPassword,
            string email,
            string firstName,
            string lastName,
            string ucn);

        Task<bool> Login(string username,
            string password);

        void Logout();


    }
}
