using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountManagmentSystemApi.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Contact { get; set; }
        public string NationalityCode { get; set; }
    }
}
