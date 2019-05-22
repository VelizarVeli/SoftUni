using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Panda.Common.ViewModels.Receipts;
using Panda.Data;
using Panda.Model;
using Panda.Services.Contracts;

namespace Panda.Services
{
    public class ReceiptService : BaseService, IReceiptService
    {
        public ReceiptService(PandaDbContext db, UserManager<PandaUser> userManager)
            :base(db, userManager)
        {
        }

        public async Task<ReceiptsViewModel> AllCurrentUserReceipts(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            var viewModel = new ReceiptsViewModel();
            if (user != null)
            {
                viewModel.Receipts = Db.Receipts
                    .Where(u => u.RecipientId == id)
                    .Select(r => new ReceiptViewModel
                    {
                        Id = r.PackageId,
                        Fee = r.Fee,
                        IssuedOn = r.IssuedOn,
                        Name = user.UserName
                    });
            }
            return viewModel;
        }
    }
}