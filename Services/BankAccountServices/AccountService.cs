using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagmentSystemApi.Services.BankAccountServices
{
    public class AccountService : IAccount
    {
        public decimal Balanece { get; set; }
        public async Task<bool> CreateAccount(AccountModel model)
        {
            if (model != null)
            {
                return true;
            }
            return false;
        }
    }
}
