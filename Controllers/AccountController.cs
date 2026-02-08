using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.BankAccountServices;
using BankAccountManagmentSystemApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagmentSystemApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private protected AccountService _service;
        public AccountController(AccountService accountService)
        {
            _service = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateAccount(request);

            if (!result)
                return BadRequest("Account creation failed");

            return Ok("Account has been created successfully");
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
