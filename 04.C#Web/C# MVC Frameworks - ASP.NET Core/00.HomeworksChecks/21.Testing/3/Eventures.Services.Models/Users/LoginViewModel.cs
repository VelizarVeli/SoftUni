using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models.Users
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
