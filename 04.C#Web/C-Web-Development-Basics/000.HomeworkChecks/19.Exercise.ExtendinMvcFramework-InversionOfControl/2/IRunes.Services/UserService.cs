using IRunes.Data;
using IRunes.Models.Models;
using IRunes.Models.ViewModels.Users;
using IRunes.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.Services
{
    public class UserService : IUserService
    {
        public bool CheckIfUserExists(string username)
        {
            using (var db = new IRunesDbContext())
            {
                return db.Users.Any(u => u.Username == username);
            }
        }

        public void CreateUser(RegisterViewModel model)
        {
            var user = new User { Username = model.Username, Password = model.Password, Email = model.Email };
            using (var db = new IRunesDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public LoginViewModel GetUser(string login)
        {
            using (var db = new IRunesDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username.ToLower() == login || u.Email.ToLower() == login);
                var model = new LoginViewModel { Login = user.Username, Password = user.Password };

                return model;
            }
        }

        public bool CheckIfEmailIsTaken(string email)
        {
            using (var db = new IRunesDbContext())
            {
                return db.Users.Any(u => u.Email == email);
            }
        }
    }
}
