using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Results;

namespace SIS.Demo
{
    public class AccountController
    {
        private const string UsernameKey = "username";
        private const string FullNameKey = "full-name";
        private const string PasswordKey = "password";
        private const string ConfirmPasswordKey = "confirm-password";

        private static string _errorMessage;

        private bool IsLoginDataValid(IHttpRequest request)
        {
            if (!request.FormData.ContainsKey(UsernameKey) ||
                !request.FormData.ContainsKey(PasswordKey))
            {
                return false;
            }

            return true;
        }

        private bool IsRegisterDataValid(IHttpRequest request)
        {
            if (!request.FormData.ContainsKey(UsernameKey) ||
                !request.FormData.ContainsKey(FullNameKey) ||
                !request.FormData.ContainsKey(PasswordKey) ||
                !request.FormData.ContainsKey(ConfirmPasswordKey))
            {
                return false;
            }

            return true;
        }

        private bool DoPasswordsMatch(IHttpRequest request)
        {
            if (request.FormData[PasswordKey] != request.FormData[ConfirmPasswordKey])
            {
                return false;
            }

            return true;
        }

        public IHttpResponse Login()
        {
            var responseString = $@"<h1>Login</h1>
<br />
<br />
<form method=""post"">
    <div>
        <label>Username: </label>
        <input type=""text"" name={UsernameKey} placeholder=""Username"">
    </div>
    <div>
        <label>Password: </label>
        <input type=""password"" name={PasswordKey} placeholder=""Password"">
    </div>
    <div style=""color:red"">{_errorMessage}</div>
    <input type=""submit"" value=""Login"">
</form>
<div>Back to <a href=""/"">Home</a>";
            return new HtmlResult(responseString, HttpResponseStatusCode.Ok);
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            if (!this.IsLoginDataValid(request))
            {
                _errorMessage = "You have empty fields";
                return new RedirectResult("/login");
            }

            _errorMessage = string.Empty;

            var responseString =
                $@"<h1>You are trying to login with username: {request.FormData[UsernameKey]} and password: {request.FormData[PasswordKey]}</h1>
<div>Back to <a href=""/"">Home</a>";

            return new HtmlResult(responseString, HttpResponseStatusCode.Ok);
        }

        public IHttpResponse Register()
        {
            var responseString = $@"<h1>Register</h1>
<br />
<br />
<form method=""POST"">
    <div>
        <label>Full name: </label>
        <input type=""text"" name={FullNameKey} placeholder=""Full name"">
    </div>
    <div>
        <label>Username: </label>
        <input type=""text"" name={UsernameKey} placeholder=""Username"">
    </div>
    <div>
        <label>Password: </label>
        <input type=""password"" name={PasswordKey} placeholder=""Password"">
    </div>
    <div>
        <label>Confirm password: </label>
        <input type=""password"" name={ConfirmPasswordKey} placeholder=""Confirm password"">
    </div>
    <div style=""color:red"">{_errorMessage}</div>
    <input type=""submit"" value=""Register"">
</form>
<div>Back to <a href=""/"">Home</a>";
            return new HtmlResult(responseString, HttpResponseStatusCode.Ok);
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            if (!this.IsRegisterDataValid(request))
            {
                _errorMessage = "You have empty fields";
                return new RedirectResult("/register");
            }

            if (!this.DoPasswordsMatch(request))
            {
                _errorMessage = "Password and confirm password don't match";
                return new RedirectResult("/register");
            }

            _errorMessage = string.Empty;

            var responseString =
                $"<h1>You are trying to register with:</h1>" +
                $"<h2>Username = {request.FormData[UsernameKey]}</h2>" +
                $"<h2>Full name = {request.FormData[FullNameKey]}</h2>" +
                $"<h2>Password = {request.FormData[PasswordKey]}</h2>" +
                $"<h2>Confirm password = {request.FormData[ConfirmPasswordKey]}</h2>" +
                $@"<div>Back to <a href=""/"">Home</a>";

            return new HtmlResult(responseString, HttpResponseStatusCode.Ok);
        }
    }
}