using IRunes.Models;

namespace IRunes.Services.Contracts
{
    public interface IUserService
    {
	void AddUser(string username, string firstName,
	    string lastName, string email, string hashedPassword);
	bool Exists(string username);
	User GetUserByEmail(string email);
	User GetUserByUsername(string username);
    }
}
