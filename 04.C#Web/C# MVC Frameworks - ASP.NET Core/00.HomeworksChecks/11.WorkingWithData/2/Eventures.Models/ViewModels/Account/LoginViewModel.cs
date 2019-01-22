
using System.ComponentModel.DataAnnotations;

namespace Eventures.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string Password { get; set; }
    }
}
