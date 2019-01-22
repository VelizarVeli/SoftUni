using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Eventures.Services.Contracts
{
    public interface IUsersService
    {
        Task<bool> CreateUser<T>(T model, string password);

        Task<bool> LoginUser(string username, string password, bool isPersistent, bool lockOutOnFailure);

        Task<bool> ExternalLoginUser(ExternalLoginInfo info);
    }
}
