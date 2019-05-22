using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Panda.Model;
using Panda.Services.Contracts;
using Panda.Web.Models;

namespace Panda.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPackageService _packageService;
        private readonly UserManager<PandaUser> _currentUser;

        public HomeController(IPackageService packageService, UserManager<PandaUser> currentUser)
        {
            _packageService = packageService;
            _currentUser = currentUser;
        }

        [Authorize]
        public async Task<IActionResult> Index(string id)
        {
            var packages = await _packageService.AllPackages(_currentUser.GetUserId(User));
            
            return View(packages);
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