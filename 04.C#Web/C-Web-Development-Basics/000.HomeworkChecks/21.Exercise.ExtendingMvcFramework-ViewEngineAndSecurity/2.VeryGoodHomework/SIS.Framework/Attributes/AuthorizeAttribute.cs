using System;
using System.Linq;
using SIS.Framework.Security.Contracts;

namespace SIS.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthorizeAttribute : Attribute
    {
	private readonly string[] roles;

	public AuthorizeAttribute() { }

	public AuthorizeAttribute(params string[] roles)
	{
	    this.roles = roles;
	}

	public bool IsAuthorized(IIdentity identity)
	{
	    if (identity == null) return false;
	    if (!identity.IsAuthenticated) return false;
	    if (!roles.Any()) return true;
	    if (!identity.Roles.Any()) return false;
	    foreach (var role in identity.Roles)
	    {
		if (roles.Contains(role)) return true;
	    }
	    return false;
	}
    }
}
