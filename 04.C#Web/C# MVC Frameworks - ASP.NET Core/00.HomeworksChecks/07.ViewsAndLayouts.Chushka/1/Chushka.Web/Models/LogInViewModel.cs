using System.ComponentModel.DataAnnotations;

namespace Chushka.Web.Models
{
    public class LogInViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
