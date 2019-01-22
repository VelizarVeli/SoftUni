using System;

namespace SIS.HTTP.Cookies.Contracts
{
    public interface IHttpCookie
    {
	DateTime Expires { get; }
	bool IsHttpOnly { get; }
	int MaxAge { get; }
	string Name { get; }
	string Path { get; }
	string Value { get; }
    }
}
