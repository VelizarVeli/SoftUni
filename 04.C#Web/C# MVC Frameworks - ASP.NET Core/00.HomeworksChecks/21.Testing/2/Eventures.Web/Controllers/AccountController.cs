using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eventures.Data;
using Eventures.Models;
using Eventures.Web.Models;
using Eventures.Web.Structures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventures.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<EventureUser> signIn;
        private readonly UserManager<EventureUser> userManager;

        private readonly EventuresDbContext context;
        private readonly ILogger logger;
        private readonly IMapper _mapper;


        public AccountController(SignInManager<EventureUser> signIn, ILogger<AccountController> logger, UserManager<EventureUser> userManager,IMapper mapper, EventuresDbContext context)
        {
            this.context = context;
            this.signIn = signIn;
            this.logger = logger;
            this.userManager = userManager;
            
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.signIn.SignOutAsync().Wait();

            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Manage(int pageIndex = 1)
        {
            var users = context.Users.AsQueryable().ProjectTo<UserViewModel>(_mapper.ConfigurationProvider);
            
            var model = await PaginatedList<UserViewModel>.CreateAsync(users, pageIndex, 10);

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Manage(string userId)
        {
            var user = await signIn.UserManager.FindByIdAsync(userId);
            
            var roles = await signIn.UserManager.GetRolesAsync(user);

            if (roles.Contains("Administrator"))
            {
                await signIn.UserManager.RemoveFromRoleAsync(user, "Administrator");
                await signIn.UserManager.AddToRoleAsync(user, "User");
            }
            else
            {
                await signIn.UserManager.RemoveFromRoleAsync(user, "User");
                await signIn.UserManager.AddToRoleAsync(user, "Administrator");
            }

            if (signIn.UserManager.GetUserId(User) == userId)
            {
                await signIn.SignOutAsync();
            }

            return this.Redirect("~/");
        }
    }

    public class UserViewModel
    {
        public string Username { get; set; }
        public string Id { get; set; }
    }
}