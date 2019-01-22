namespace SIS.Framework.Services
{
    using Contracts;
    using Data;
    using Models;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly RunesDbContext dB;
        private readonly IHashService hashService;

        public UserService(RunesDbContext dB, IHashService hashService)
        {
            this.dB = dB;
            this.hashService = hashService;
        }

        public bool ExistsByUsernameAndPassword(string username, string password)
        {
            var hashedPassword = this.hashService.Hash(password);
            return this.dB.Users.Any(u => u.Username == username && u.HashedPassword == hashedPassword);
        }

        public void CreateAndSaveUser(string userName, string email, string password)
        {
            var hashedPassword = this.hashService.Hash(password);

            var user = new User()
            {
                Username = userName,
                Email = email,
                HashedPassword = hashedPassword
            };

            try
            {
                this.dB.Users.Add(user);
                this.dB.SaveChanges();
            }
            catch (Exception exception)
            {
                // TODO: server exception
                return;
            }
        }
    }
}