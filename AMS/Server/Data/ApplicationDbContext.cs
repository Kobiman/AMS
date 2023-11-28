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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasData(
                    new Game { Name= "Monday Special", Srl=1},
                    new Game { Name= "Pioneer", Srl=2},
                    new Game { Name= "Lucky Tuesday", Srl=3},
                    new Game { Name= "Vag East", Srl=4},
                    new Game { Name= "Mid-Week", Srl=5},
                    new Game { Name= "Vag West", Srl=6},
                    new Game { Name= "Fortune Thursday", Srl=7},
                    new Game { Name= "Africa", Srl=8},
                    new Game { Name= "Friday Bonanza", Srl=9},
                    new Game { Name= "Obiri", Srl=10},
                    new Game { Name= "National", Srl=11},
                    new Game { Name= "Old Soldier", Srl=12},
                    new Game { Name= "Aseda", Srl=13},
                    new Game { Name= "Sunday Special", Srl=14}
                );
        }
        
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

    }
}