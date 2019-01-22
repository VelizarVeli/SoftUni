namespace Eventures.WebApp.ViewModels.Account
{
	using System.ComponentModel.DataAnnotations;

	public class LoginViewModel
	{
		[Display(Name = "Username")]
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
