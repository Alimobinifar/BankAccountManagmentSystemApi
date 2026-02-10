using BankAccountManagmentSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagmentSystemApi.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AccountModel> Accounts => Set<AccountModel>();
    }
}
