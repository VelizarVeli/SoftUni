namespace SIS.Framework.Services.Contracts
{
    public interface IUserService
    {
        bool ExistsByUsernameAndPassword(string username, string password);

        void CreateAndSaveUser(string userName, string email, string hashedPassword);
    }
}