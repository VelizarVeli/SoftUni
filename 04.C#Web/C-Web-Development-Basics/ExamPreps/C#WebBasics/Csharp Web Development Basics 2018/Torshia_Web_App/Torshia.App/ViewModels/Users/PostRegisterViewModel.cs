namespace Torshia.App.ViewModels.Users
{
    using Torshia.App.Models.Enums;

    public class PostRegisterViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }
    }
}