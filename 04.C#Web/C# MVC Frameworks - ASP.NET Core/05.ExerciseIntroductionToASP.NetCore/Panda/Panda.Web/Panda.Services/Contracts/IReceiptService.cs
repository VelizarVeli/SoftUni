using System;
using System.Threading.Tasks;
using Panda.Common.ViewModels.Receipts;

namespace Panda.Services.Contracts
{
    public interface IReceiptService
    {
        Task<ReceiptsViewModel> AllCurrentUserReceipts(string id);
        Task<ReceiptDetailsViewModel> Details(Guid id, string userId);
        Task<ReceiptDetailsViewModel> CreateReceipt(Guid id, string userId);
    }
}
