using BankAccountManagmentSystemApi.Data;
using BankAccountManagmentSystemApi.Enums;
using BankAccountManagmentSystemApi.Models;
using BankAccountManagmentSystemApi.Services.Interfaces;
using BankAccountManagmentSystemApi.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagmentSystemApi.Services.BankAccountServices
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _Context;

        public TransactionService (AppDbContext context)
        {
            _Context = context;
        }


        // کدوم حساب ؟ اینجا حسابی نداره ! 
        public async Task<bool> Deposit(TransactionDto transactionDto)
        {
            // پیدا کردن کاربر از جدول Users
            var user = await _Context.Users.FindAsync(transactionDto.UserId);
            if (user == null) return false;

            // بروزرسانی موجودیS
            //user.Balance += transactionDto.Amount;

            // ثبت تراکنش
            var transaction = new TransactionModel
            {
                UserId = transactionDto.UserId,
                Amount = transactionDto.Amount,
                TransactionType = TransactionType.Deposit,
                
            };

            _Context.Transactions.Add(transaction);
            await _Context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Withdraw(TransactionDto transactionDto)
        {
            var user = await _Context.Users.FindAsync(transactionDto.UserId);
            if (user == null) return false;

            //if (user.Balance < transactionDto.Amount) return false;

            //user.Balance -= transactionDto.Amount;

            var transaction = new TransactionModel
            {
                UserId = transactionDto.UserId,
                Amount = transactionDto.Amount,
                TransactionType = TransactionType.Withdrow,
               
            };

            _Context.Transactions.Add(transaction);
            await _Context.SaveChangesAsync();

            return true;
        }

    }

     
        

        
}
