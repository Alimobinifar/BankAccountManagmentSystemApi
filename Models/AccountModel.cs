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
        public string OwnerName { get; set; }
        public string OwnerFamily { get; set; }
        public string OwnerContact { get; set; }
        public string OwnerNationalityCode { get; set; }
        public decimal Balance { get; set; }
    }
}
