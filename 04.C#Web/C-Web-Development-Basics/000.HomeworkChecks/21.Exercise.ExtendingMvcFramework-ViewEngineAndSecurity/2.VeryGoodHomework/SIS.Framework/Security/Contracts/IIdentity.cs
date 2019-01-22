using System.Collections.Generic;

namespace SIS.Framework.Security.Contracts
{
    public interface IIdentity
    {
	string Email { get; set; }
	bool IsAuthenticated { get; set; }
	string PasswordHash { get; set; }
	IEnumerable<string> Roles { get; set; }
	string Username { get; set; }
    }
}
