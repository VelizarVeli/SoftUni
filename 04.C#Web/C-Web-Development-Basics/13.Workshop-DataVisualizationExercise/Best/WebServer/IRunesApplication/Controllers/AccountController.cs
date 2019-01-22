namespace WebServer.IRunesApplication.Controllers
{
    using Server.Http.Contracts;
    using Server.Http.Response;
    using Server.Http;
    using ViewModels;
    using ViewModels.Account;
    using System;
    using Services;
    using Services.Contracts;

    public class AccountController : BaseController
    {
        private const string RegisterView = @"account\register";
        private const string LoginView = @"account\login";

        private readonly IUserService users;

        public AccountController(IHttpRequest request)
            :base(request)
        {
            this.users = new UserService();
        }

        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.SetDefaultViewData();

            return this.FileViewResponse(LoginView);
        }

        public IHttpResponse Login(LoginViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Passsword))
            {
                this.ShowError("You have empty fields");
                return FileViewResponse(LoginView);
            }

            var success = users.Find(model.Username, model.Passsword);

            if (success)
            {
                this.LoginUser(model.Username);

                this.ViewData["anonymousUser"] = "none";
                this.ViewData["loggedUser"] = "block";
                this.ViewData["welcome"] = "block";
                this.ViewData["name"] = $"{model.Username}";
                this.ViewData["welcome-btn"] = "none";
                LoginUser(model.Username);
                return FileViewResponse("/Home/Index");
            }
            else
            {
                this.ShowError("Invalid user details");
                return FileViewResponse(LoginView);
            }
        }

        public IHttpResponse Register()
        {
            this.SetDefaultViewData();
            this.ViewData["showError"] = "none";
            return this.FileViewResponse(RegisterView);
        }

        public IHttpResponse Register(RegisterUserViewModel model)
        {
            this.SetDefaultViewData();

            if (model.Username.Length < 3
                || model.Password.Length < 3
                || model.ConfirmPassword != model.Password)
            {
                this.ShowError("Invalid user details");
                return this.FileViewResponse(RegisterView);
            }

            var succes = users.Create(model.Username, model.Password, model.Email);

            if (succes)
            {
                this.SetDefaultViewData();
                this.ViewData["welcome"] = "block";
                this.ViewData["name"] = $"{model.Username}";
                this.ViewData["anonymousUser"] = "none";
                this.ViewData["loggedUser"] = "block";
                this.ViewData["welcome-btn"] = "none";
                return FileViewResponse("/Home/Index");
            }
            else
            {
                return FileViewResponse(RegisterView);
            }
        }

        public IHttpResponse Profile()
        {
            if (!this.Request.Session.Contains(SessionStore.CurrentUserKey))
            {
                throw new InvalidOperationException("There is no logged in user.");
            }

            var username = this.Request.Session.Get<string>(SessionStore.CurrentUserKey);

            //var profile = this.users.Profile(username);

            //if (profile == null)
            //{
            //    throw new InvalidOperationException($"The user {username} could not be found in the database.");
            //}

            //this.ViewData["username"] = profile.Username;
            //this.ViewData["registration-date"] = profile.RegistrationDate.ToShortDateString();
            //this.ViewData["orders-count"] = profile.OrdersCount.ToString();

            return FileViewResponse(@"account\profile");
        }

        public IHttpResponse Logout()
        {
            if (this.Request.Session == null)
            {
                return new RedirectResponse("/Users/Login");

            }
            this.Request.Session.Clear();
            return new RedirectResponse("/Users/Login");

        }

        private void SetDefaultViewData() => this.ViewData["authDisplay"] = "none";

        private void LoginUser(string username)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, username);
            this.Request.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
        }        
    }
}
