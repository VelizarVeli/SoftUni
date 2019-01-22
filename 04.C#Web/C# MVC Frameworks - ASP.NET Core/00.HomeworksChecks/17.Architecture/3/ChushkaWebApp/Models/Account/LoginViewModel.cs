namespace EventWebApp.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "You must enter an username")]
        [RegularExpression(@"[\w-.^~]+",ErrorMessage = "May only contain alphanumeric characters ,dashes and underscores,dots, asterisks and tildes")]
        [StringLength(50, ErrorMessage = "Username length must between 3 and 50 characters", MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "You must enter an password")]
        [StringLength(50, ErrorMessage = "Password length must between 5 and 50 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
