using SIS.Framework.Models;

namespace IRunes.App.ViewModels
{
    public class RegisterViewModel : ViewModel
    {
	public string Email { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Password { get; set; }
	public string Username { get; set; }
    }
}
