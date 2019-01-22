using Eventures.Models;
using Eventures.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Services
{
    public class UsersService : IUsersService
    {
        private const string ROLE_NAME_USER = "User"; 
        private const string ROLE_NAME_ADMIN = "Admin";

        private readonly SignInManager<User> _singInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UsersService(SignInManager<User> singInManager, UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            this._singInManager = singInManager;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task<bool> Login(string username, string password)
        {
            if (username == null || password == null)
            {
                return false;
            }

            var user = this.GetUser(username).Result;

            if (user == null)
            {
                return false;
            }

            var result = await this._singInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async void Logout()
        {
            await this._singInManager.SignOutAsync();
        }

        public async Task<bool> Register(
            string username, string password, string confirmPassword, string email, string firstName, string lastName, string ucn)
        {
            if (username == null ||
               password == null ||
               confirmPassword == null ||
               email == null ||
               firstName == null ||
               lastName == null ||
               ucn == null)
                return false;

            if (password != confirmPassword)
            {
                return false;
            }

            var user = new User
            {
                UserName = username,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UniqueCitizenNumber = ucn
            };

            var userCreateResult = await this._userManager.CreateAsync(user, password);

            if (!userCreateResult.Succeeded)
            {
                return false;
            }

            IdentityResult addRoleResult = null;
            if (this._userManager.Users.Count() == 1)
            {
                addRoleResult = await this._userManager.AddToRoleAsync(user, ROLE_NAME_ADMIN);
            }
            else
            {
                if (!await this._roleManager.RoleExistsAsync(ROLE_NAME_USER))
                {
                    var role = new IdentityRole(ROLE_NAME_USER);
                    await this._roleManager.CreateAsync(role);
                }
                addRoleResult = await this._userManager.AddToRoleAsync(user, ROLE_NAME_USER);
            }

            
            if (!addRoleResult.Succeeded)
            {
              
                return false;
            }

            return true;
        }

        public async Task<User> GetUser(string username)
        {
            var user = await this._userManager.FindByNameAsync(username);

            return user;
        }
    }
}
