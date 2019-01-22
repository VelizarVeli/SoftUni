using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models.Users
{
    public class ExternalLoginViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Username")]
        [RegularExpression(@"(\S)+", ErrorMessage = " White Space is not allowed in Usernames")]
        public string UserName { get; set; }
        
        [EmailAddress]
        [Display(Name = "И-мейл")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Exactly 10 numbers")]
        public string Ucn { get; set; }
    }
}
