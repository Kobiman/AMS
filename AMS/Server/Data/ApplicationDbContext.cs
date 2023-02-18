using AMS.Server.Models;
using AMS.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AMS.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Account>()
        //        .HasData(
        //            new Account { AccountName = "Pay-In", Balance = 0, CreatedDate = DateTime.Now, Type = "Revenue", Transactions = new List<AccountTransaction>() },
        //            new Account { AccountName = "Pay-Out", Balance = 0, CreatedDate = DateTime.Now, Type = "Liability", Transactions = new List<AccountTransaction>() },
        //            new Account { AccountName = "GCB Bank", Balance = 0, CreatedDate = DateTime.Now, Type = "Asset", Transactions = new List<AccountTransaction>() }
        //        );
        //}
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Debtors> Debtors { get; set; }       
        public DbSet<Sales> Sales { get; set; }

        public DbSet<Payout> Payouts { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        
    }
}