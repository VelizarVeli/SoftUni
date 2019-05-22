using System.Threading.Tasks;
using Panda.Common.ViewModels.Receipts;

namespace Panda.Services.Contracts
{
    public interface IReceiptService
    {
        Task<ReceiptsViewModel> AllCurrentUserReceipts(string id);
    }
}
