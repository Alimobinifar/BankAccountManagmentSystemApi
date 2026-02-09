using System.ComponentModel.DataAnnotations;

namespace BankAccountManagmentSystemApi.ViewModels
{
    public class UpdateAccountDto
    {
        public int recordId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerFamily { get; set; }
        public string PhoneNumber { get; set; }
    }
}
