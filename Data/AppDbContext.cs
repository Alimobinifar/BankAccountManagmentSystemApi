using BankAccountManagmentSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagmentSystemApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AccountModel> Accounts => Set<AccountModel>();
        public DbSet<AuditLogModel> AuditLogs => Set<AuditLogModel>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>()
                .Property(a => a.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<AccountModel>()
                .Property(a => a.Balance)
                .HasColumnType("decimal(18,2)");
            

        }



    }
}
