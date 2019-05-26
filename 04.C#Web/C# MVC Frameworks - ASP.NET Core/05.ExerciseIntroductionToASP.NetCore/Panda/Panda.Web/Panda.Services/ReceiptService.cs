using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Panda.Common.ViewModels.Receipts;
using Panda.Data;
using Panda.Model;
using Panda.Model.Enums;
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
                        Id = r.Id,
                        Fee = r.Fee,
                        IssuedOn = r.IssuedOn,
                        Name = user.UserName
                    });
            }
            return viewModel;
        }

        public async Task<ReceiptDetailsViewModel> Details(Guid id, string userId)
        {
            var currentReceipt = await Db.Receipts.FirstOrDefaultAsync(i => i.Id == id);
            var package = await Db.Packages.FirstOrDefaultAsync(a => a.Id == currentReceipt.PackageId);
            var currentUsername = await UserManager.FindByIdAsync(userId);
            var viewModel = new ReceiptDetailsViewModel
            {
                ReceiptNumber = currentReceipt.Id,
                IssuedOn = currentReceipt.IssuedOn,
                DeliveryAddress = package.ShippingAddress,
                Weight = package.Weight,
                PackageDescription = package.Description,
                Recipient = currentUsername.UserName,
                Total = package.Weight * 2.67
            };
            return viewModel;
        }

        public async Task<ReceiptDetailsViewModel> CreateReceipt(Guid id, string userId)
        {
            var currentPackage = Db.Packages.FirstOrDefault(i => i.Id == id);
            var receipt = new Receipt
            {
                PackageId = id,
                RecipientId = userId,
                IssuedOn = DateTime.UtcNow,
                Fee = Math.Round(((decimal)currentPackage.Weight * 2.67M), 2)
            };

            currentPackage.Status = Status.Acquired;
            await Db.Receipts.AddAsync(receipt);
            Db.Packages.Update(currentPackage);
            await Db.SaveChangesAsync();

            var receiptDetails = Details(receipt.Id, userId);

            return await receiptDetails;
        }
    }
}