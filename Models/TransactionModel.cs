using BankAccountManagmentSystemApi.Enums;

namespace BankAccountManagmentSystemApi.Models
{
    public class TransactionModel:BaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public int AccountId { get; set; }
        
    }
}
