namespace Eventures.WebApp.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterInputModel
    {
        [Required]
        [MinLength(3)]
        [RegularExpression(@"[A-Za-z\~\-\\_\*]+")]
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Display(Name = "UNC")]
        public string UniqueCitizenNumber { get; set; }
    }
}