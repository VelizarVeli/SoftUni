using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Eventures.Services
{
    public class UsersService : IUsersService
    {
        private SignInManager<EventuresUser> signInManager;

        private EventuresDbContext db;

        private IMapper mapper;

        public UsersService(SignInManager<EventuresUser> signInManager, EventuresDbContext db, IMapper mapper)
        {
            this.signInManager = signInManager;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<bool> CreateUser<T>(T model, string password)
        {
            var user = mapper.Map<EventuresUser>(model);

            var result = this.signInManager.UserManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                var roleResult = this.signInManager.UserManager.AddToRoleAsync(user, "User").Result;

                if (roleResult.Errors.Any())
                {
                    return false;
                }

                await this.signInManager.SignInAsync(user, isPersistent: false);

                return true;
            }

            return false;
        }

        public async Task<bool> LoginUser(string username, string password, bool isPersistent, bool lockOutOnFailure)
        {
            var result = await this.signInManager.PasswordSignInAsync(username, password, isPersistent, lockOutOnFailure);

            return result.Succeeded;
        }

        public async Task<bool> ExternalLoginUser(ExternalLoginInfo info)
        {
            var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName);
            var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname);
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            var user = await this.signInManager.UserManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new EventuresUser
                {
                    UserName = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                var result = await this.signInManager.UserManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    var addExternalLogin = await this.signInManager.UserManager.AddLoginAsync(user, info);

                    if (addExternalLogin.Succeeded)
                    {
                        var roleResult = this.signInManager.UserManager.AddToRoleAsync(user, "User").Result;

                        if (roleResult.Errors.Any())
                        {
                            return false;
                        }

                        await this.signInManager.SignInAsync(user, isPersistent: false);

                        return true;
                    }
                }

                return false;
            }
            else
            {
                var result = await this.signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

                if (result.Succeeded)
                {
                    return true;
                }

                return false;  
            }
        }
    }
}
