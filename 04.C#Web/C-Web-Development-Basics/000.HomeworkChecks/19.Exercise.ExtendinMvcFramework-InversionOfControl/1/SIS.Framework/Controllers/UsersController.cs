namespace SIS.Framework.Controllers
{
    using ActionResults.Contracts;
    using Attributes.Methods;
    using Common;
    using HTTP.Responses.Contracts;
    using Services.Contracts;
    using ViewModels;
    using WebServer.Results;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!this.ModelState.IsValid.HasValue || !this.ModelState.IsValid.Value)
            {
                return this.RedirectToAction("/users/login");
            }

            if (this.userService.ExistsByUsernameAndPassword(model.Username, model.Password))
            {
                return this.RedirectToAction("/users/login");
            }

            //var response = new RedirectResult("/");
            //this.SignInUser(model.Username, response);

            return this.RedirectToAction("/home/index");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        public IActionResult Register(RegisterViewModel model)
        {
            this.userService.CreateAndSaveUser(model.Username, model.Email, model.Password);

            //var response = new RedirectResult("/");
            //this.SignInUser(model.Username, response);

            return this.RedirectToAction("/home/index");
        }

        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(Constants.HttpCookieKey))
            {
                return new RedirectResult("/");
            }

            var cookie = this.Request.Cookies.GetCookie(Constants.HttpCookieKey);
            cookie.Delete();

            var response = new RedirectResult("/");
            response.Cookies.Add(cookie);

            return response;
        }

        //private void ValidateRegisterPassword(string password, string confirmPassword)
        //{
        //    if (string.IsNullOrEmpty(password) || password.Length < 6)
        //    {
        //        this.BadRequestError(Messages.InvalidPassword);
        //    }

        //    if (password != confirmPassword)
        //    {
        //        this.BadRequestError(Messages.PasswordsDontMatch);
        //    }
        //}

        //private void ValidateRegisterUsername(string userName)
        //{
        //    if (string.IsNullOrEmpty(userName) || userName.Length < 4)
        //    {
        //        this.BadRequestError(Messages.InvalidUsername);
        //    }

        //    if (this.Db.Users.Any(u => u.Username == userName))
        //    {
        //        this.BadRequestError(Messages.UserExists);
        //    }
        //}
    }
}