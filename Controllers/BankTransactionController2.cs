using BankAccountManagmentSystemApi.Services.BankAccountServices;
using BankAccountManagmentSystemApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagmentSystemApi.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class BankTransactionController2 : ControllerBase
    {
        private protected TransactionService2 _service;
        public BankTransactionController2(TransactionService2 accountService)
        {
            _service = accountService;
        }
        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositTransaction request)
        {

            var result = await _service.Deposit(request);
            if (!result)
                return BadRequest("Withdraw failed");
            return Ok(result);

        }


        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrowTransaction request)
        {
            var result = await _service.Withdraw(request);

            if (!result)
                return BadRequest("Withdraw failed");

            return Ok("Withdraw successful");
        }



    }
}
