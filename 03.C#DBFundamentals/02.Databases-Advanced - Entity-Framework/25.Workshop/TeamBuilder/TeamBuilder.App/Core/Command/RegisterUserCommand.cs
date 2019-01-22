using System;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Command
{
    public class RegisterUserCommand : ICommand
    {
        private readonly TeamBuilderContext context;
        private readonly AuthenticationManager _authManager;

        public RegisterUserCommand(AuthenticationManager authManager)
        {
            this.context = new TeamBuilderContext();
            this._authManager = authManager;
        }

        public string Execute(string[] args)
        {
            Check.CheckLength(7, args);

            string username = args[0];
            string password = args[1];
            string passwordRepeat = args[2];
            string firstName = args[3];
            string lastName = args[4];
            int age;
            GenderEnum gender;

            if (username.Length < Constants.MinUsernameLength || username.Length > Constants.MaxUsernameLength)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid, username));
            }

            if (password.Length < Constants.MinPasswordLength || password.Length > Constants.MaxPasswordLength)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, password));
            }

            if (!int.TryParse(args[5], out age))
            {
                throw new ArgumentException(Constants.ErrorMessages.AgeNotValid);
            }

            if (age < 0)
            {
                throw new ArgumentException(Constants.ErrorMessages.AgeNotValid);
            }

            if (!Enum.TryParse<GenderEnum>(args[6], out gender))
            {
                throw new ArgumentException(Constants.ErrorMessages.GenderNotValid);
            }

            if (password != passwordRepeat)
            {
                throw new ArgumentException(Constants.ErrorMessages.PasswordDoesNotMatch);
            }

            if (CommandHelper.IsUserExisting(username))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.UsernameIsTaken, username));
            }

            if (_authManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);   
            }

            User entity = new User()
            {
                Username = username,
                Password = password,
                Age = age,
                FirstName = firstName,
                LastName = lastName
            };

            this.context.Users.Add(entity);
            this.context.SaveChanges();

            return string.Format($"User {username} was registered successfully!");
        }
    }
}
