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
    public class AccountService : IAccountService
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
                // ثبت تراکنش
                var account = new AccountModel
                {
                    UserId = request.UserId,
                    Balance = request.Balance,
                    CreatedAt = DateTime.Now,
                    AccountType = request.BankAccountType

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
                var record = _context.Accounts.Where(x => x.Id == request.recordId).FirstOrDefault();
                if (record != null)
                {

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

        // استفاده از جوین در EF Core
        // استفاده از یک Dto جدید برای برگرداندن 
        public async Task<List<AccountViewModel>> GetAllAccounts()
        {
            try
            {
                var response = await (from a in _context.Accounts
                                      join u in _context.Users on a.UserId equals u.UserID
                                      select new AccountViewModel
                                      {
                                          AccountId = a.Id,
                                          OwerName = u.Name + " " + u.Family,  
                                          Balance = a.Balance
                                      }).ToListAsync();  
                return response;
            }
            catch (Exception ex)
            {
                return new List<AccountViewModel>();
            }
        }

        public async Task<ResponseModel<AccountModel>> GetAccountsByUserIdAsync(
           int UserId,
           int accountType)
        {
            ResponseModel<AccountModel> result = new ResponseModel<AccountModel>();
            try
            {
                var query = _context.Accounts
                    .Where(a => a.UserId == UserId);
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
