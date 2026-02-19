using BankAccountManagmentSystemApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace BankAccountManagmentSystemApi.ViewModels
{
    public class CreateAccountRequest
    {
        public int UserId { get; set; }
        public BankAccountType BankAccountType { get; set; }    
        public decimal Balance { get; set; }
    }

}
