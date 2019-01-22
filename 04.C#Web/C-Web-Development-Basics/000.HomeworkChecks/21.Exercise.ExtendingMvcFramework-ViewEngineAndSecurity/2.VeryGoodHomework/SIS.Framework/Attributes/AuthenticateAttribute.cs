using System;
using SIS.Framework.Security.Contracts;

namespace SIS.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthenticateAttribute : Attribute
    {
	public bool IsAuthenticated(IIdentity identity)
	{
	    if (identity == null) return false;
	    if (!identity.IsAuthenticated) return false;
	    return true;
	}
    }
}
