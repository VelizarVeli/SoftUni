namespace WebServer.IRunesApplication.Services
{
    using Data;
    using Services.Contracts;
    using System.Linq;
    using Data.Models;
    using System;
    using ViewModels.Account;

    public class UserService : IUserService
    {
        public bool Create(string username, string password, string email)
        {
            using (var db = new IRunesDbContext())
            {
                if (db.Users.Any(u => u.Username == username))
                {
                    return false;
                }

                var user = new User()
                {
                    Username = username,
                    Password = password,
                    Email = email
                };

                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool Find(string username,string password)
        {
            using (var db = new IRunesDbContext())
            {
                return db.Users.Any(u => u.Username == username && u.Password == password);
            }
        }

        public ProfileViewModel Profile(string username)
        {
            using (var db = new IRunesDbContext())
            {
                return db
                        .Users
                        .Where(u => u.Username == username)
                        .Select(u => new ProfileViewModel()
                        {
                            Username = u.Username
                        })
                        .FirstOrDefault();                  
            }
        }

        public int? GetUserId(string username)
        {
            using (var db = new IRunesDbContext())
            {
                var id = db
                    .Users
                    .Where(u => u.Username == username)
                    .Select(u => u.Id)
                    .FirstOrDefault();

                return id != 0 ? (int?)id : null;
            }
        }
    }
}
