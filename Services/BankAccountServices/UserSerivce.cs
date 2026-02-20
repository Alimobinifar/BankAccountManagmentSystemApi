using BankAccountManagmentSystemApi.Data;
using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.Interfaces;
using BankAccountManagmentSystemApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagmentSystemApi.Services.BankAccountServices
{
    public class UserSerivce : IUserService
    {
        private protected AppDbContext _context;

        public UserSerivce(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAccount(CreateUserAccount createUserAccount)
        {
            try
            {
                var User = new User
                {
                    UserID = createUserAccount.UserID,
                    Name = createUserAccount.Name,
                    Family = createUserAccount.Family,
                    Contact = createUserAccount.Contact,
                    NationalityCode = createUserAccount.NationalityCode,
                };
                await _context.Users.AddAsync(User);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAccount(UpdateUserAccount updateUserAccount)
        {
            try
            {
                var response = _context.Users.Where(b => b.UserID == updateUserAccount.UserID).FirstOrDefault();
                if (response != null)
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

        public async Task<List<User>> GetAllAccounts()
        {
            try
            {
                var response = await _context.Users.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }
        public async Task<ResponseModel<User>> GetNationalityCodeAsync(string NationalityCode)
        {
            ResponseModel<User> result = new ResponseModel<User>();
            try
            {
                var query = _context.Users
                    .Where(a => a.NationalityCode == NationalityCode);


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