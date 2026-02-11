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


        // Get user account by nationality code

        // Get user account by id 

        // Disable Account => Add a isActive to medel (Inheritance ! (Generic))
        
        // Account type => Enums (Private, Moshtarak)

        // Get accounts by type
        // test 
    }
    
}
