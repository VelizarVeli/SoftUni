namespace EventWebApp.Services.Contracts
{
    using System.Collections.Generic;
    using Data.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Models.Account;

    public interface IAccountService
    {
        IActionResult Register(RegisterViewModel user);

        IActionResult Login(LoginViewModel model);

        IActionResult Logout();

        ApplicationUser GetUser(string username);

        void CreateUserExternal();

        AuthenticationProperties ConfigureExternalLoginProperties(string provider, string redirectUrl);

        void Demote(string id);

        void Promote(string id);

        IList<AdminPanelUsersViewModel> AdminPanelUsers();
    }
}
