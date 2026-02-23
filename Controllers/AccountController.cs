using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.BankAccountServices;
using BankAccountManagmentSystemApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagmentSystemApi.Controllers
{
    // Post : account
    [ApiController]
    [Route("Api/Account")]
    public class AccountController : ControllerBase
    {
        private protected AccountService _service;
        public AccountController(AccountService accountService)
        {
            _service = accountService;
        }
        
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateAccount(request);

            if (!result)
                return BadRequest("Account creation failed");

            return Ok("Account has been created successfully");
        }
        
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _service.UpdateAccount(request);

            if (!result)
                return BadRequest("Account update failed");

            return Ok("Account has been updated successfully");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var response = await _service.GetAllAccounts();
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("No record found ... ");
        }

        [HttpGet]
        [Route("GetAccountsByUserIdAsync")]
        public async Task<IActionResult> GetAccountsByUserIdAsync([FromQuery] int UserId, [FromQuery] int accountType)
        {
            var response = await _service.GetAccountsByUserIdAsync(UserId, accountType);

            if (response != null && !response.Error)
                return Ok(response);

            return BadRequest(response?.Msg ?? "No record found ...");
        }
    }

}
