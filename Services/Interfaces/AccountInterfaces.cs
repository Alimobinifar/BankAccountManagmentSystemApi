using BankAccountManagmentSystemApi.Models;

namespace BankAccountManagmentSystemApi.Services.Interfaces
{

    public interface IAccount
    {
        public Task<bool> CreateAccount(AccountModel model);
    }
}
