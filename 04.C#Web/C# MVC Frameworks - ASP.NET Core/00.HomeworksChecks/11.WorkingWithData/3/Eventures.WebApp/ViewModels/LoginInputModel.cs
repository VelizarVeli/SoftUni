namespace Eventures.WebApp.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginInputModel
    {
        [Required]
        [MinLength(3)]
        [RegularExpression(@"[A-Za-z\~\-\\_\*]+")]
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}