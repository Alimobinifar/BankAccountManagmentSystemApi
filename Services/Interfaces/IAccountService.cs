using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.ViewModels;

namespace BankAccountManagmentSystemApi.Services.Interfaces
{

    public interface IAccountService
    {
        public Task<bool> CreateAccount(CreateAccountRequest request);
        public Task<bool> UpdateAccount(UpdateAccountRequest request);
        public Task<List<AccountViewModel>> GetAllAccounts();
        public Task<ResponseModel<AccountModel>> GetAccountsByUserIdAsync(int UserId, int accountTaype);
           
    }
}
