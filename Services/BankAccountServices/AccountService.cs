using BankAccountManagmentSystemApi.Data;
using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.Interfaces;
using BankAccountManagmentSystemApi.ViewModels;

namespace BankAccountManagmentSystemApi.Services.BankAccountServices
{
    public class AccountService : IAccount
    {
        private protected AppDbContext _context;
        
        public AccountService(AppDbContext context)
        {
            _context = context;
        }
     
        public async Task<bool> CreateAccount(CreateAccountRequest request)
        {
            try
            {
                var account = new AccountModel
                {
                    OwnerName = request.OwnerName,
                    OwnerFamily = request.OwnerFamily,
                    OwnerContact = request.OwnerContact,
                    OwnerNationalityCode = request.OwnerNationalityCode,
                    Balance = request.Balance,
                    CreatedAt = DateTime.Now
                };

                await _context.Accounts.AddAsync(account);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
