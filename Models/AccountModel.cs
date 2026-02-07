namespace BankAccountManagmentSystemApi.Models
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerFamily {  get; set; }
        public string OwnerContact {  get; set; }
        public string OwnerNationalityCode {  get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
