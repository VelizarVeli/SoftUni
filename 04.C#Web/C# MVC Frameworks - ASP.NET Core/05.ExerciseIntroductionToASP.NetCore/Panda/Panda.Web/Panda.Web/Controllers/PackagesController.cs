using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public async Task<IActionResult> Details(Guid id, string userId)
        {
            var packageDetails = await _packageService.Details(id, _currentUser.GetUserId(User));
            return View(packageDetails);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreatePackage()
        {
            var viewModel = _packageService.GetUserNamesPackage();

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePackage(CreatePackageViewModel model)
        {
            await _packageService.CreatePackage(model);
            return RedirectToAction("AllPending");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllPending()
        {
            var allPending = _packageService.AllPending();

            return View("AllPending", allPending);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Ship(Guid id)
        {
            await _packageService.Ship(id);

            return RedirectToAction("AllShipped");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllShipped()
        {
            var allShipped = _packageService.AllShipped();

            return View("AllShipped", allShipped);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Deliver(Guid id)
        {
            await _packageService.Deliver(id);

            return RedirectToAction("AllDelivered");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllDelivered()
        {
            var allDelivered = _packageService.AllDelivered();

            return View("AllDelivered", allDelivered);
        }
    }
}