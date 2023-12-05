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
        //    modelBuilder.Entity<Game>()
        //        .HasData(
        //            new Game { Name= "MONDAY SPECIAL", Srl=1},
        //            new Game { Name= "PIONEER", Srl=2},
        //            new Game { Name= "LUCKY TUESDAY", Srl=3},
        //            new Game { Name= "VAG EAST", Srl=4},
        //            new Game { Name= "MID-WEEK", Srl=5},
        //            new Game { Name= "VAG WEST", Srl=6},
        //            new Game { Name= "FORTUNE THURSDAY", Srl=7},
        //            new Game { Name= "AFRICA", Srl=8},
        //            new Game { Name= "FRIDAY BONANZA", Srl=9},
        //            new Game { Name= "OBIRI", Srl=10},
        //            new Game { Name= "NATIONAL", Srl=11},
        //            new Game { Name= "OLD SOLDIER", Srl=12},
        //            new Game { Name= "ASEDA", Srl=13},
        //            new Game { Name= "SUNDAY SPECIAL", Srl=14}
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
        public DbSet<Audit> Audits { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<AgentExpense> AgentExpenses { get; set; }

        public DbSet<AgentGameCommission> AgentGameCommissions { get; set; }

    }
}