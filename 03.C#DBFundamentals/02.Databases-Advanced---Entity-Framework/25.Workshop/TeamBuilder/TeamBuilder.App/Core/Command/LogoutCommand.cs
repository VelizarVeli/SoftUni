using System;
using TeamBuilder.App.Utilities;

namespace TeamBuilder.App.Core.Command
{
    public class LogoutCommand : ICommand
    {
        private readonly AuthenticationManager _authManager;

        public LogoutCommand(AuthenticationManager authManager)
        {
            this._authManager = authManager;
        }

        public string Execute(string[] args)
        {
            if (!this._authManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }

            string username = this._authManager.GetCurrenUser().Username;

            this._authManager.Logout();

            return string.Format($"User {username} successfully logged out!");
        }
    }
}
