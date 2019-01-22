using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRunesWebApp.Models;
using IRunesWebApp.Services;
using IRunesWebApp.VIewModels;
using Services;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Controllers;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        [HttpGet]
        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid.HasValue || !ModelState.IsValid.Value)
            {
                return this.RedirectToAction("/users/login");
            }

            var userExists = this.usersService
                .ExistsByUsernameAndPassword(
                    model.Username,
                    model.Password);

            if (!userExists)
            {
                return this.RedirectToAction("/users/login");
            }
            this.Request.Session.AddParameter("username", model.Username);
            return this.RedirectToAction("/home/index");
        }
        //[HttpGet]
        //public IHttpResponse Register(IHttpRequest request) => this.View();


        //[HttpPost]
        //public IHttpResponse Register(IHttpRequest request)
        //{
        //    var userName = request.FormData["username"].ToString().Trim();
        //    var password = request.FormData["password"].ToString();
        //    var confirmPassword = request.FormData["confirmPassword"].ToString();

        //    
        //    //if (string.IsNullOrWhiteSpace(userName) || userName.Length < 4)
        //    //{
        //    //    return new BadRequestResult("Please provide valid username with length of 4 or more characters.");
        //    //}

        //    //if (this.Context.Users.Any(x => x.Username == userName))
        //    //{
        //    //    return new BadRequestResult("User with the same name already exists.");
        //    //}

        //    //if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
        //    //{
        //    //    return new BadRequestResult("Please provide password of length 6 or more.");
        //    //}

        //    if (password != confirmPassword)
        //    {
        //        return new BadRequestResult(
        //            "Passwords do not match.",
        //            HttpResponseStatusCode.SeeOther);
        //    }

        //    
        //    var hashedPassword = this.hashService.Hash(password);

        //    
        //    var user = new User
        //    {
        //        Username = userName,
        //        HashedPassword = hashedPassword,
        //    };
        //    this.Context.Users.Add(user);

        //    try
        //    {
        //        this.Context.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        
        //        return new BadRequestResult(
        //            e.Message,
        //            HttpResponseStatusCode.InternalServerError);
        //    }

        //    var response = new RedirectResult("/");
        //    this.SignInUser(userName, response, request);

        //    
        //    return response;
        //}


    }
}
