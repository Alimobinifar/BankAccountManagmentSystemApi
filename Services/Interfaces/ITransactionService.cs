using BankAccountManagmentSystemApi.ViewModels;

namespace BankAccountManagmentSystemApi.Services.Interfaces
{
    public interface ITransactionService
    {
        public Task <bool> Deposit(TransactionDto transaction);
        public Task <bool> Withdraw(TransactionDto transaction);
    }
}
