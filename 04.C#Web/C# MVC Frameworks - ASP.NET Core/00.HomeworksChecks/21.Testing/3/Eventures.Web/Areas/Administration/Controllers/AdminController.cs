using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Web.Areas.Administration.Models;
using Eventures.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly EventuresDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IAdminService _adminService;

        public AdminController(EventuresDbContext dbContext, RoleManager<IdentityRole> roleManager, 
            UserManager<User> userManager, IAdminService adminService)
        {
            this._dbContext = dbContext;
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._adminService = adminService;
        }

        public async Task<IActionResult> Index()
        {
            var allUsers = await this._adminService.AllAsync();
            var testRoles = this._roleManager.Roles.ToList();

            var roles = this._roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                });

            return View(new UserViewModel
            {
                Roles = roles,
                Users = allUsers
            });            
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var roleExists = await this._roleManager.RoleExistsAsync(model.Role);
            var user = await this._userManager.FindByIdAsync(model.UserId);
            var userExists = user != null;

            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            await this._userManager.AddToRoleAsync(user, model.Role);

            TempData.AddSuccessMessage($"The user {user.UserName} is added to the role {model.Role}");

            return RedirectToAction(nameof(Index));
        }
    }
}