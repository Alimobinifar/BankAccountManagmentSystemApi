using BankAccountManagmentSystemApi.Data;
using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.Interfaces;
using BankAccountManagmentSystemApi.Services.MainServices;
using BankAccountManagmentSystemApi.ViewModels;
using Microsoft.EntityFrameworkCore.Query.Internal;
namespace BankAccountManagmentSystemApi.Services.BankAccountServices
{
    public class TransactionService2 : IAccont1
    {

        private protected AppDbContext _context;
        public TransactionService2(AppDbContext context)
        {
            _context = context;
          
        }
        public async Task<bool> Deposit(DepositTransaction request)
        {
            var account = await _context.Accounts.FindAsync(request.Id);

            if (account == null)
                return false;

            account.Balance += request.Amount;

            var transaction = new AccountModel
            {
                AccountId = request.Id,
                Amount = request.Amount,

            };

            await _context.Accounts.AddAsync(transaction);

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> Withdraw(WithdrowTransaction request)
        {
            var account = await _context.Accounts.FindAsync(request.Id);

            if (account == null)
                return false;

            if (account.Balance < request.Amount)
                return false;

            account.Balance -= request.Amount;

            var transaction = new AccountModel
            {
                AccountId = account.Id,
                Amount = request.Amount,
              
            };

            await _context.Accounts.AddAsync(transaction);

            await _context.SaveChangesAsync();

            return true;
        }



    }
}









