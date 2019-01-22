using System.ComponentModel.DataAnnotations;

namespace Chushka.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please, Enter your name")]
        [Display(Name = "Username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [DataType(DataType.Text)]
        [MaxLength(100, ErrorMessage = "The name cannot be longer than 100 symbols")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
