using System.Linq;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Bonus
	{
		public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
		{
		    User user = context.Users.SingleOrDefault(i => i.Username == username);

		    if (user == null)
		    {
		        return $"User {username} not found";
		    }

		    if (user.Email == newEmail)
		    {
		        return $"Email {user.Email} is already taken";
		    }

		    user.Email = newEmail;

		    context.SaveChanges();

		    return $"Changed {username}'s email successfully";

        }
    }
}
