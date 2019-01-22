using System;
using System.Linq;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Command
{
    public class LoginCommand : ICommand
    {
        private readonly AuthenticationManager _authManager;
        private readonly TeamBuilderContext _context;

        public LoginCommand(AuthenticationManager authManager)
        {
            this._context = new TeamBuilderContext();
            this._authManager = authManager;
        }

        public string Execute(string[] args)
        {
            Check.CheckLength(2, args);
            if (this._authManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            string username = args[0];
            string password = args[1];

            if (!this._context.Users.Any(x => x.Username == username))
            {
                throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }

            User user = this._context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                throw new  ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }

            this._authManager.Login(user);

            return string.Format($"User {username} successfully logged in!");
        }
    }
}
