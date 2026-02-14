using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagmentSystemApi.Services.Interfaces
{

    public interface IAccount
    {
        public Task<bool> CreateAccount(CreateAccountRequest request);
        public Task<bool> UpdateAccount(UpdateAccountRequest request);
        public Task<List<AccountModel>> GetAllAccounts();
    }
    public interface IAccont1
    {
        public Task<bool> Deposit(DepositTransaction request);
        public Task<bool> Withdraw(WithdrowTransaction request);
    }


}
