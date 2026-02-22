using BankAccountManagmentSystemApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace BankAccountManagmentSystemApi.Models
{
    public class TransactionModel:BaseModel
    {
        [Key]
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public int AccountId { get; set; }
        
    }
}
