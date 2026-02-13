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
               
                Amount = request.Amount,
                Balance = account.Balance,
                OwnerContact = account.OwnerContact,
                OwnerNationalityCode = account.OwnerNationalityCode,
                OwnerName = account.OwnerName,
                OwnerFamily = account.OwnerFamily,

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
                Amount = request.Amount,
                Balance = account.Balance,
                OwnerContact = account.OwnerContact,
                OwnerNationalityCode = account.OwnerNationalityCode,
                OwnerName = account.OwnerName,
                OwnerFamily = account.OwnerFamily,

            };

            await _context.Accounts.AddAsync(transaction);

            await _context.SaveChangesAsync();

            return true;
        }



    }
}









