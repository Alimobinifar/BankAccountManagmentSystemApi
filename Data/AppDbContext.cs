using BankAccountManagmentSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagmentSystemApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AccountModel> Accounts => Set<AccountModel>();
        public DbSet<AuditLogModel> AuditLogs => Set<AuditLogModel>();
        public DbSet<TransactionModel> Transactions => Set<TransactionModel>();
        public DbSet<User> users => Set<User>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Balance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<TransactionModel>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);
        }






    }
}
