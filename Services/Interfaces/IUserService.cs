using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.ViewModels;

namespace BankAccountManagmentSystemApi.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CreateAccount(CreateUserAccount createUserAccount);
        public Task<bool> UpdateAccount(UpdateUserAccount updateUserAccount);
        public Task<List<User>> GetAllAccounts();
        public Task<ResponseModel<User>> GetNationalityCodeAsync(string NationalityCode);


    }
}
