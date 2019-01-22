namespace SIS.HTTP.Cookies.Contracts
{
    public interface IHttpCookieCollection
    {
        void AddCookie(HttpCookie cookie);

        bool ContainsCookie(string key);

        HttpCookie GetCookie(string key);

        bool HasCookies();
    }
}