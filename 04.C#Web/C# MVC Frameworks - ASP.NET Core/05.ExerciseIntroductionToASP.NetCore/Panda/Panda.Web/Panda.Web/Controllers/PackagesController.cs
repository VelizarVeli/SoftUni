using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Panda.Model;
using Panda.Services.Contracts;

namespace Panda.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackageService _packageService;
        private readonly UserManager<PandaUser> _currentUser;

        public PackagesController(IPackageService packageService, UserManager<PandaUser> currentUser)
        {
            _packageService = packageService;
            _currentUser = currentUser;

        }

        public async Task<IActionResult> Details(Guid id, string userId)
        {
            var packageDetails = await _packageService.Details(id, _currentUser.GetUserId(User));
            return View(packageDetails);
        }
    }
}