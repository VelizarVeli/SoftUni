using System.Linq;
using IRunes.Data;
using IRunes.Models;
using IRunes.Services.Contracts;

namespace IRunes.Services
{
    public class UserService : IUserService
    {
	private readonly IRunesDbContext Context;

	public UserService(IRunesDbContext dbContext)
	{
	    Context = dbContext;
	}

	public void AddUser(string username, string firstName, string lastName, string email, string password)
	{
	    User user = new User()
	    {
		Username = username,
		FirstName = firstName,
		LastName = lastName,
		Email = email,
		Password = password
	    };
	    Context.Users.Add(user);
	    Context.SaveChanges();
	}

	public bool Exists(string username)
	{
	    return Context.Users.Any(u => u.Username == username);
	}

	public User GetUserByEmail(string email)
	{
	    User user = Context.Users
		.Where(u => u.Email == email)
		.SingleOrDefault();
	    return user;
	}

	public User GetUserByUsername(string username)
	{
	    User user = Context.Users
		.Where(u => u.Username == username)
		.SingleOrDefault();
	    return user;
	}
    }
}
