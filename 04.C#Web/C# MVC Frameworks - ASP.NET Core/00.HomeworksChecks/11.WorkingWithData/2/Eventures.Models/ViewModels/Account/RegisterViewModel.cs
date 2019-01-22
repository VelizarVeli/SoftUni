using System.ComponentModel.DataAnnotations;

namespace Eventures.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(3, ErrorMessage = "Last Name must be at least {1} characters long!")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(3, ErrorMessage = "First Name must be at least {1} characters long!")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "UCN")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "UCN must be at exactly {1} characters long!")]
        public string UCN { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters long")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
