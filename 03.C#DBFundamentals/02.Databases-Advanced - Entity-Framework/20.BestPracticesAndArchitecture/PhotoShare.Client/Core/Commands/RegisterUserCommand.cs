using PhotoShare.Client.Core.Dtos;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class RegisterUserCommand : ICommand
    {
        private readonly IUserService userService;

        public RegisterUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            string username = data[0];
            string passowrd = data[1];
            string reapeatPassword = data[2];
            string email = data[3];

            var registerUserDto = new RegisterUserDto
            {
                Username = username,
                Password = passowrd,
                Email = email
            };

            if (!IsValid(registerUserDto))
            {
                throw new ArgumentException("Invalid data!");
            }

            var userExists = this.userService.Exists(username);

            if (userExists)
            {
                throw new InvalidOperationException($"Username {username} is already taken!");
            }

            if (passowrd != reapeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            this.userService.Register(username, passowrd, email);

            return $"User {username} was registered successfully!";
        }

        private bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
