using System.Threading.Tasks;

namespace SIS.WebServer.Contracts
{
    public interface IConnectionHandler
    {
	Task ProcessRequestAsync();
    }
}
