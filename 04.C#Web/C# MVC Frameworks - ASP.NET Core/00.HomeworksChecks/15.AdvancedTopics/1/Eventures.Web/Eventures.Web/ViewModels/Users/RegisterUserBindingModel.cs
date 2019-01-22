using Eventures.Common;
using Eventures.Web.ViewModels.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.ViewModels.Users
{
    public class RegisterUserBindingModel
    {
        [Required]
        [Display(Name = "Username")]
        [IsUnique(nameof(Username),ErrorMessage = ErrorMessages.NotUniqueUsername)]
        [MinLength(3, ErrorMessage = ErrorMessages.UsernameLength)]
        [RegularExpression(@"^[\w\-\.\*\~]+$", ErrorMessage = ErrorMessages.NotAllowedUsernameChars)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [IsUnique(nameof(Email), ErrorMessage = ErrorMessages.NotUniqueEmail)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = ErrorMessages.PasswordLenght, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = ErrorMessages.PasswordsNotMatch)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "UCN")]
        [IsUnique(nameof(UCN),ErrorMessage = ErrorMessages.NotUniqueUCN)]
        [RegularExpression(@"^[\d]{10}$", ErrorMessage = ErrorMessages.UcnLenght)]
        public string UCN { get; set; }
    }
}
