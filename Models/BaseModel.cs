namespace BankAccountManagmentSystemApi.Models
{
    public class BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
