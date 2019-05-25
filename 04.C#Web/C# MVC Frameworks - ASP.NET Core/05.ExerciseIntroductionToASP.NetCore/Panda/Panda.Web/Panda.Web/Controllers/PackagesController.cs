using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Panda.Common.ViewModels.Packages;
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

        public IActionResult CreatePackage()
        {
            var viewModel = _packageService.GetUserNamesPackage();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePackage(CreatePackageViewModel model)
        {
            await _packageService.CreatePackage(model);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AllPending()
        {
            var allPending = _packageService.AllPending();

            return View("AllPending", allPending);
        }

        public async Task<IActionResult> Ship(Guid id)
        {
            await _packageService.Ship(id);

            return RedirectToAction("AllPending");
        }
    }
}