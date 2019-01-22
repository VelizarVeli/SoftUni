namespace EventuresWebApp.Web.ViewModels.Accounts
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Username should be at least 3 symbols long.")]
        [RegularExpression(@"^[A-Za-z0-9_\-\.*~]+$", ErrorMessage = "Username may only contain alphanumeric characters, dashes, underscores, dots, asterisks and tildes.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter valid e-mail address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "UCN should be exactly 10 symbols long.")]
        [Display(Name = "UCN")]
        public string UniqueCitizenNumber { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Username should be at least 5 symbols long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and the confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
