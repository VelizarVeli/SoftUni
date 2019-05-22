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
    }
}