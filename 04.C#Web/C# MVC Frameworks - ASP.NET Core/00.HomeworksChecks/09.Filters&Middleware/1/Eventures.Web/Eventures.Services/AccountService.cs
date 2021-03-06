﻿namespace Eventures.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Contracts;
    using Models;

    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<bool> Register(string username, string email, string password, string confirmPassword, string firstName, string lastName, string ucn)
        {
            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                UniqueCitizenNumber = ucn,
                UserName = username,
                Email = email,
            };

            // Adds the user to the db
            var userCreateResult = await this.userManager.CreateAsync(user, password);
            if (!userCreateResult.Succeeded)
            {
                return false;
            }

            IdentityResult addRoleResult = null;

            if (this.userManager.Users.Count() == 1)
            {
                addRoleResult = await this.userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                addRoleResult = await this.userManager.AddToRoleAsync(user, "User");
            }

            if (!addRoleResult.Succeeded)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Login(string username, string password)
        {
            var user = this.GetUser(username).Result;
            if (user == null)
            {
                return false;
            }

            var result = await this.signInManager.PasswordSignInAsync(user, password, false, false);
            return result.Succeeded;
        }

        public async Task<User> GetUser(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);
            return user;
        }

        public async void Logout()
        {
            await this.signInManager.SignOutAsync(); ;
        }
    }
}
