using System;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Command
{
  public  class DeleteUserCommand:ICommand
    {
        private readonly TeamBuilderContext _context;
        private readonly AuthenticationManager _authManager;

        public DeleteUserCommand(AuthenticationManager authManager)
        {
            this._context = new TeamBuilderContext();
            this._authManager = authManager;
        }

        public string Execute(string[] args)
        {
            User user = this._authManager.GetCurrenUser();

            if (user == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }

            user.IsDeleted = true;
            this._context.Users.Update(user);
            this._context.SaveChanges();

            return $"User {user.Username} was deleted successfully!";
        }
    }
}
