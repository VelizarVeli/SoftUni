using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IRunes.Services.Contracts
{
    public interface IDbInitializationService
    {
	Task<bool> InitializeDatabaseAsync(DbContext dbContext);
    }
}
