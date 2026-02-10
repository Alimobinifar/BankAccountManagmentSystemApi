namespace BankAccountManagmentSystemApi.Models
{
    public class BaseModel
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

    }
}
