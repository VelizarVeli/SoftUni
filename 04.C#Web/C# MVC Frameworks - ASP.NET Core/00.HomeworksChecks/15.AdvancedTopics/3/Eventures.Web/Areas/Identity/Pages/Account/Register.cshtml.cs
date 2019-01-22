using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Eventures.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Eventures.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [RegularExpression("[\\w,-^,_,.,*,~]{3,}", ErrorMessage = "Username is invalid!")]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [MinLength(5, ErrorMessage = "Password must be at least 5 characters long")]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
            public string ConfirmPassword { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [MinLength(3, ErrorMessage = "First Name must be at least {1} characters long!")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [MinLength(3, ErrorMessage = "Last Name must be at least {1} characters long!")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [MinLength(10, ErrorMessage = "UCN must be exactly {1} characters long!")]
            [MaxLength(10, ErrorMessage = "UCN must be exactly {1} characters long!")]
            public string UCN { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Username,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    UCN = Input.UCN
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                await _userManager.AddToRoleAsync(user, "User");

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
