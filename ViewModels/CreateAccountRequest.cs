using BankAccountManagmentSystemApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace BankAccountManagmentSystemApi.ViewModels
{
    public class CreateAccountRequest
    {
        public string OwnerName { get; set; }
        public string OwnerFamily { get; set; }
        public string OwnerContact { get; set; }
        public string OwnerNationalityCode { get; set; }
        public BankAccountType BankAccountType { get; set; }    
        public decimal Balance { get; set; }
    }

}
