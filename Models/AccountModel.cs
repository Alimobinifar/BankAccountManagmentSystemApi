using BankAccountManagmentSystemApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountManagmentSystemApi.Models
{
    public class AccountModel: BaseModel
    {
        [Key]
        public int Id { get; set; }
        public BankAccountType AccountType { get; set; }
        public string OwnerName { get; set; }
        public string OwnerFamily { get; set; }
        public string OwnerContact { get; set; }
        public string OwnerNationalityCode { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }



    }
}
