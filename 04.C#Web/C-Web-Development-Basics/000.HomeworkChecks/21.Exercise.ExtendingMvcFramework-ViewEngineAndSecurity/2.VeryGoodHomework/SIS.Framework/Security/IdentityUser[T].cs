using System;
using System.Collections.Generic;
using SIS.Framework.Security.Contracts;

namespace SIS.Framework.Security
{
    public class IdentityUserT<TIdentifier> : IIdentity
	where TIdentifier : IEquatable<TIdentifier>
    {
	public virtual string Email { get; set; }
	public virtual TIdentifier Id { get; set; }
	public virtual bool IsAuthenticated { get; set; }
	public virtual string PasswordHash { get; set; }
	public virtual IEnumerable<string> Roles { get; set; }
	public virtual string Username { get; set; }
    }
}
