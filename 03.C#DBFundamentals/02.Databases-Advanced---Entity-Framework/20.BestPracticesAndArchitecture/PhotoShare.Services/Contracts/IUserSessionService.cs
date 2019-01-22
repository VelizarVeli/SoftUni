namespace PhotoShare.Services.Contracts
{
    using Models;

    public interface IUserSessionService
    {
        User User { get; }

        void LogIn(string username);

        void LogOut();

        bool IsLoggedIn();

        string GetUsername();
    }
}