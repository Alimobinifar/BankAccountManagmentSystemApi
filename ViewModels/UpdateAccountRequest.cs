using BankAccountManagmentSystemApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace BankAccountManagmentSystemApi.ViewModels
{
    public class UpdateAccountRequest
    {
        public int recordId { get; set; }
        public BankAccountType BankAccountType { get; set; }
        public decimal Balance { get; set; }

    }
}
