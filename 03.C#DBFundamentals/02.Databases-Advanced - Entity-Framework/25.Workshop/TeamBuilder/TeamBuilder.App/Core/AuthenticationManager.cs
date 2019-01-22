using System;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core
{
    public class AuthenticationManager
    {
        public User loggedInUser { get; private set; }

        public AuthenticationManager()
        {
        }

        public void Login(User user)
        {
            if (this.loggedInUser != null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            this.loggedInUser = user;
        }

        public void Logout()
        {
            if (this.loggedInUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }

            this.loggedInUser = null;
        }
        public void Authorizer()
        {
            if (loggedInUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
        }
        public void Authorize()
        {
            if (!IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
        }

        public bool IsAuthenticated()
        {
            return this.loggedInUser != null;
        }

        public User GetCurrenUser()
        {
            Authorize();
            return this.loggedInUser;
        }
    }
}
