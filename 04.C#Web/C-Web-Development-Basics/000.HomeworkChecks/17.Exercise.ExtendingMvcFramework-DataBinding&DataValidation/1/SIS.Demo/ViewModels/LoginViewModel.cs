namespace SIS.Demo.ViewModels
{
    using Framework.Attributes.Property;

    public class LoginViewModel
    {
        [Regex("[A-Z]+")]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
