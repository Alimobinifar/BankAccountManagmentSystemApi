using BankAccountManagmentSystemApi.Data;
using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.Interfaces;
using BankAccountManagmentSystemApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagmentSystemApi.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // POST: Deposit
        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit([FromBody] TransactionDto dto)
        {
            // connect to TransactionService
            var result = await _transactionService.Deposit(dto);
            if (!result)
                return BadRequest("Deposit failed. User not found.");

            return Ok("Deposit successful");
        } 


        // POST : Withdrow
        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] TransactionDto dto)
        {
            // connect to TransactionService
            var result = await _transactionService.Withdraw(dto);
            if (!result)
                return BadRequest("Withdrawal failed. Either user not found or insufficient balance.");

            return Ok("Withdrawal successful");
        }


    }  
    
}