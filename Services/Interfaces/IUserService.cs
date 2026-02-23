using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.ViewModels;

namespace BankAccountManagmentSystemApi.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CreateUser(CreateUserAccount createUserAccount);
        public Task<bool> UpdateUser(UpdateUserAccount updateUserAccount);
        public Task<ResponseModel<User>> GetAllUsers();
        public Task<ResponseModel<User>> GetUsersByNationalityCodeAsync(string NationalityCode);


    }
}
