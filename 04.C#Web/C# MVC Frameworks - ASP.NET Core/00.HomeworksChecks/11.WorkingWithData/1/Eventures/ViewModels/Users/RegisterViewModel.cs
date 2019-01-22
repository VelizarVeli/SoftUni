using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.ViewModels.Users
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 symbols long.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 symbols long.")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "UCN")]
        [StringLength(maximumLength:10,MinimumLength = 10)]
        public string UniqueCitizenNumber { get; set; }
    }
}