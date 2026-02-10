using BankAccountManagmentSystemApi.Data;
using BankAccountManagmentSystemApi.Enums;
using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.Interfaces;
using BankAccountManagmentSystemApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<bool> UpdateAccount(UpdateAccountDto request)
        {
            try
            {
                var record = _context.Accounts.Where(x => x.Id == request.recordId).FirstOrDefault();
                if (record != null)
                {
                    record.OwnerName = request.OwnerName;
                    record.OwnerFamily = request.OwnerFamily;
                    record.OwnerContact = request.PhoneNumber;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public async Task<List<AccountModel>> GetAllAccounts()
        {
            try
            {
                var response = await _context.Accounts.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                return new List<AccountModel>();
            }
        }

        public async Task<ResponseModel<AccountModel>> GetUserAccountsByNationalityCodeAsync(
            string nationalityCode,
            int accountType)
        {
            ResponseModel<AccountModel> result = new ResponseModel<AccountModel>();
            try
            {
                var query = _context.Accounts
                    .Where(a => a.OwnerNationalityCode == nationalityCode);
                if (accountType != 0)
                {
                    query = query.Where(a => (int)a.AccountType == accountType);
                }
                result.List = await query.ToListAsync();
                result.Msg = "Accounts retrieved successfully.";
                result.Error = false;
                return result;
            }
            catch (Exception ex)
            {
                result.Msg = ex.Message;
                result.Error = true;
                return result;
            }
        }





    }
}
