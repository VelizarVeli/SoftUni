using IRunes.Models.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services.Contracts
{
    public interface IUserService
    {
        bool CheckIfUserExists(string username);

        void CreateUser(RegisterViewModel model);

        LoginViewModel GetUser(string login);

        bool CheckIfEmailIsTaken(string email);
    }
}
