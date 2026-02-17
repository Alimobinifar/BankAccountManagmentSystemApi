using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.ViewModels;

namespace BankAccountManagmentSystemApi.Services.Interfaces
{

    public interface IAccountService
    {
        public Task<bool> CreateAccount(CreateAccountRequest request);
        public Task<bool> UpdateAccount(UpdateAccountDto request);
    }
}
