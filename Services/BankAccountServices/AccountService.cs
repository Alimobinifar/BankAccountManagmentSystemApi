using BankAccountManagmentSystemApi.Data;
using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagmentSystemApi.Services.BankAccountServices
{
    public class AccountService : IAccount
    {
        private protected AppDbContext _context;
        public decimal Balanece { get; set; }
        public AccountService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAccount(AccountModel model)
        {
            try
            {
                await _context.Accounts.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
