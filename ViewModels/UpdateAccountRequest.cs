using System.ComponentModel.DataAnnotations;

namespace BankAccountManagmentSystemApi.ViewModels
{
    public class UpdateAccountRequest
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string OwnerFamily { get; set; }
        public string OwnerContact { get; set; }
        
    }
}
