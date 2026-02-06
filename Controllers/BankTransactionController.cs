using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagmentSystemApi.Controllers
{
    public class BankTransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
