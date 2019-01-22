namespace IRunesWebApp.Services
{
    public interface IUsersService
    {
        bool ExistsByUsernameAndPassword(string username, string password);
    }
}
