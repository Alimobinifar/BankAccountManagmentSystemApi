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
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // تنظیم decimal precision
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

            // مشخص کردن اسم جدول Users
            modelBuilder.Entity<User>().ToTable("Users");
        }






    }
}
