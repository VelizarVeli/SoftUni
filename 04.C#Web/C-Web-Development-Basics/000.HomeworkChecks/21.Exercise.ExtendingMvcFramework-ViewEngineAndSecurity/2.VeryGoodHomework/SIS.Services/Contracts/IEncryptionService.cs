namespace SIS.Services.Contracts
{
    public interface IEncryptionService
    {
	string HashPassword(string password);
    }
}
