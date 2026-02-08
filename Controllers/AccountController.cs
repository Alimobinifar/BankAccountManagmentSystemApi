using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.BankAccountServices;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagmentSystemApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private protected AccountService _servie;
        public AccountController(AccountService accountService)
        {
            _servie = accountService;
        }

        [HttpGet("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody]AccountModel model) 
        {
            var respone = await _servie.CreateAccount(model);
            if (respone)
            {
                return Ok("Account has been created successfully");
            }
            return BadRequest();
        }

        
        // Update Account
        // Show balance
        // Withdraw
        // Deposite
        
        public async Task<IActionResult> UpdateAccount()
        {
            return Ok("Account updated");
        }

    }
}
