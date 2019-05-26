using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Panda.Model;
using Panda.Services.Contracts;

namespace Panda.Web.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptService _receiptService;
        private readonly UserManager<PandaUser> _currentUser;

        public ReceiptsController(IReceiptService receiptService, UserManager<PandaUser> currentUser)
        {
            _receiptService = receiptService;
            _currentUser = currentUser;
        }

        public async Task<IActionResult> Index()
        {
            var receipts = await _receiptService.AllCurrentUserReceipts(_currentUser.GetUserId(User));

            return View("Index", receipts);
        }

        public async Task<IActionResult> ReceiptDetails(Guid id)
        {
            var receiptDetails = await _receiptService.Details(id, _currentUser.GetUserId(User));

            return View(receiptDetails);
        }

        public async Task<IActionResult> Acquire(Guid id)
        {
           var receiptDetails =  await _receiptService.CreateReceipt(id, _currentUser.GetUserId(User));

            return View("ReceiptDetails", receiptDetails);
        }
    }
}