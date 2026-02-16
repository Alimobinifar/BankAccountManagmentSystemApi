using BankAccountManagmentSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagmentSystemApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // Gadvale Sqlserver Account
        public DbSet<AccountModel> Accounts => Set<AccountModel>();
        // Gadvale Sqlserver AuditLogs
        public DbSet<AuditLogModel> AuditLogs => Set<AuditLogModel>();
        // Gadvale Sqlserver Transactions
        public DbSet<TransactionModel> Transactions => Set<TransactionModel>();
        // Gadvale Sqlserver users
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
