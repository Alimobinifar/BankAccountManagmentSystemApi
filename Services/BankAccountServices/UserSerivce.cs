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

        public async Task<bool> CreateUser(CreateUserAccount createUserAccount)
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
 
        public async Task<bool> UpdateUser(UpdateUserAccount updateUserAccount)
        {
            try
            {
                var response = _context.Users.Where(b => b.UserID == updateUserAccount.UserID).FirstOrDefault();
                if (response != null)
                {
                    User user = new User();
                    user.Name = updateUserAccount.Name;
                    user.Family = updateUserAccount.Family;
                    user.Contact = updateUserAccount.Contact;
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

        public async Task<ResponseModel<User>> GetAllUsers()
        {
            ResponseModel<User> res = new ResponseModel<User>();
            try
            {
                var response = await _context.Users.ToListAsync();
                res.List = response;
                res.Msg = "List retrived successfully";
            }
            catch (Exception ex)
            {
                res.Error = true;
                res.Msg = ex.InnerException.Message.ToString();
                res.StatusCode = 500;
                return res;

            }
            return res;
        }

        public async Task<ResponseModel<User>> GetUsersByNationalityCodeAsync(string NationalityCode)
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