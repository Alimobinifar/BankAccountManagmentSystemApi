using BankAccountManagmentSystemApi.Data;
using BankAccountManagmentSystemApi.Enums;
using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.Interfaces;
using BankAccountManagmentSystemApi.Services.MainServices;
using BankAccountManagmentSystemApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Json;

namespace BankAccountManagmentSystemApi.Services.BankAccountServices
{
    public class AccountService : IAccount
    {
        #region Objects 
        private protected AppDbContext _context;
        private protected AuditService _auditService;
        #endregion
        public AccountService(AppDbContext context, AuditService auditService)
        {
            _context = context;
            _auditService = auditService;
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

                AuditLogModel logModel = new AuditLogModel
                {
                    UserId = "1",
                    Action = "CreateUserAccount",
                    EntityName = "Account",
                    Details = "Create Account",
                    EventType = AuditEventType.Success,
                    CreatedAt = DateTime.UtcNow
                };

                await _auditService.LogEventAsync(logModel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAccount(UpdateAccountRequest request)
        {
            try
            {
                var record = _context.Accounts.Where(x => x.Id == request.Id).FirstOrDefault();
                if (record != null)
                {
                    record.OwnerName = request.OwnerName;
                    record.OwnerFamily = request.OwnerFamily;
                    record.OwnerContact = request.OwnerContact;
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
