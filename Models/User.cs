namespace BankAccountManagmentSystemApi.Models
{
    public class User
    {
        //  کاربر ها
        public int UserID { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; } = 0;
    }
}
