using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagmentSystemApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        public decimal Balance { get; set; }
        public AccountController()
        {
        }

        public async Task<IActionResult> CreateAccount() 
        {
            return Ok("Account created successfully");
        }

        public async Task<IActionResult> UpdateAccount()
        {
            return Ok("Account updated");
        }

    }
}
