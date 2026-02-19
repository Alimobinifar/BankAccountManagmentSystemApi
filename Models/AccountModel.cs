using BankAccountManagmentSystemApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BankAccountManagmentSystemApi.Models
{
    public class AccountModel: BaseModel
    {
        [Key]
        public int Id { get; set; }
        [JsonPropertyName("AccountType")]
        public BankAccountType AccountType { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public decimal Balance { get; set; }
    }
}
