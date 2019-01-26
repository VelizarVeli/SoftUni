﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        private readonly SignInManager<EventureUser> _signInManager;
        private readonly UserManager<EventureUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<EventureUser> userManager,
            SignInManager<EventureUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Unique Citizen Number(UCN)")]
            [RegularExpression("[0-9]{10}", ErrorMessage = "The Unique Citizen Number(UCN) should consist of exactly 10 numbers")]
            public string Ucn { get; set; }
            [Required(ErrorMessage = "First name is required!")]
            [Display(Name = "First name")]
            public string LastName { get; set; }
            [Required(ErrorMessage = "First name is required!")]
            [Display(Name = "First name")]
            public string FirstName { get; set; }
            [Required(ErrorMessage = "Username is required!")]
            [Display(Name = "Username")]
            [MinLength(3, ErrorMessage = "Username should contain at least 3 characters!")]
            [RegularExpression("^[A-Za-z0-9_-~*.]+$", ErrorMessage = "Username may only contain numbers, letters, dashes, underscores, dots, asterisks and tildes!")]
            public string Username { get; set; }
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
                var user = new EventureUser { UserName = Input.Email, Email = Input.Email,FirstName = Input.FirstName,LastName = Input.LastName,Ucn = Input.Ucn};
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (_signInManager.UserManager.Users.Count() == 1)
                    {
                        await _signInManager.UserManager.AddToRoleAsync(user, "Administrator");
                        user.Roles.Add("Administrator");
                    }
                    await _signInManager.UserManager.AddToRoleAsync(user, "User");
                    user.Roles.Add("User");

                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

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