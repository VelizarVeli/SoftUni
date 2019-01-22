using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;
using Eventures.Web.Services;
using Eventures.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly SignInManager<EventureUser> _singIn;
        private readonly IDataService dataService;

        public UsersController(SignInManager<EventureUser> signIn, IDataService dataService)
        {
            this._singIn = signIn;
            this.dataService = dataService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = new EventureUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                Ucn = model.Ucn
            };

            var result = this._singIn.UserManager.CreateAsync(user, model.Password).Result;

            if (this._singIn.UserManager.Users.Count() == 1)
            {
                var roleResult = this._singIn.UserManager.AddToRoleAsync(user, "Admin").Result;

                if (roleResult.Errors.Any())
                {
                    return this.View();
                }
            }

            if (result.Succeeded)
            {
                this._singIn.SignInAsync(user, false).Wait();
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            
            var user = this._singIn.UserManager.Users.FirstOrDefault(x => x.UserName == model.Username);

            if (user == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var result = this._singIn.CheckPasswordSignInAsync(user, model.Password, false).Result;

            if (!result.Succeeded)
            {
                return this.RedirectToAction("Error", "Home");
            }

            this._singIn.SignInAsync(user, model.RememberMe).Wait();

            return RedirectToAction("Index", "Home");
        }
       
        public IActionResult Logout()
        {
            this._singIn.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult MyEvents()
        {
            var userEvents = this.dataService.GetUserEvents(this.User.Identity.Name);
            var model = new List<EventViewModel>();

            foreach (var ev in userEvents)
            {
                var view = new EventViewModel()
                {
                    Name = ev.Event.Name,
                    Start = ev.Event.Start,
                    End = ev.Event.End,
                    TicketsOrdered = ev.TicketsCount
                };

                model.Add(view);
            }

            return this.View(model);
        }
    }
}