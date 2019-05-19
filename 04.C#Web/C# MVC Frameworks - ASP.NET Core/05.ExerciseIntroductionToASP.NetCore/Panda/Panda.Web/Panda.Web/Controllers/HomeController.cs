using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Panda.Model;
using Panda.Web.Models;

namespace Panda.Web.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager<PandaUser> signIn;
        private RoleManager<IdentityRole> roleManager;
        private readonly UserManager<PandaUser> userManager;

        public HomeController(SignInManager<PandaUser> signIn,
            RoleManager<IdentityRole> roleManager,
            UserManager<PandaUser> userManager)
        {
            this.signIn = signIn;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if (this.signIn.UserManager.Users.Count() == 2)
            {
                var currentUser = await userManager.GetUserAsync(HttpContext.User);
                await this.signIn.UserManager.AddToRoleAsync(currentUser, "Admin");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
