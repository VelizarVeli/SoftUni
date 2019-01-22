using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models.Users
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Username")]
        [RegularExpression(@"(\S)+", ErrorMessage = " White Space is not allowed in Usernames")]
        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Exactly 10 numbers")]
        public string Ucn { get; set; }
    }
}
