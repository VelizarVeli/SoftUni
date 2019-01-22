using System.ComponentModel.DataAnnotations;

namespace EVENTURES.App.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9-_.*~]{3,}$", ErrorMessage = "Username must be at least 3 characters long and can only contain alphanumeric characters dashes and underscores dots, asterisks and tildes.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Display(Name = "UCN")]
        public string UCN { get; set; }
    }
}
