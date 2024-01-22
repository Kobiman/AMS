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
        //            new Game { Id= "123ca7b8-a57a-446f-b32c-82837bddfc15", Name = "MONDAY SPECIAL", Srl = 1 },
        //            new Game { Id= "1de1f535-99e4-4d21-bb1e-e2e109f7b297", Name = "PIONEER", Srl = 2 },
        //            new Game { Id= "04730225-0ec3-4fb5-8cd3-511965dc1bd5", Name = "LUCKY TUESDAY", Srl = 3 },
        //            new Game { Id = "81025268-1b96-40c1-ba3b-b36879bbc584", Name = "VAG EAST", Srl = 4 },
        //            new Game { Id = "6bb1e8cb-47e2-4b94-b34e-8725b6bc59f0", Name = "MID-WEEK", Srl = 5 },
        //            new Game { Id = "ee5d799f-677b-43c7-962c-41ec514bb7b6", Name = "VAG WEST", Srl = 6 },
        //            new Game { Id = "9d0a75e8-8c28-4d16-8e30-ec33182b5624", Name = "FORTUNE THURSDAY", Srl = 7 },
        //            new Game { Id = "e46d5ee8-3ca6-42aa-a502-2e674e5a054a", Name = "AFRICA", Srl = 8 },
        //            new Game { Id = "bcf305bc-7770-449c-a1dc-f519018c634c", Name = "FRIDAY BONANZA", Srl = 9 },
        //            new Game { Id = "2861a600-2dd1-4ea5-8156-dc5116d93d70", Name = "OBIRI", Srl = 10 },
        //            new Game { Id = "4f081941-48ee-4e13-ad58-56bda415d164", Name = "NATIONAL", Srl = 11 },
        //            new Game { Id = "cc3f68e8-4624-4557-a5c1-392304761c51", Name = "OLD SOLDIER", Srl = 12 },
        //            new Game { Id = "d38a9387-0e85-496f-98e3-bee4620e6a46", Name = "ASEDA", Srl = 13 },
        //            new Game { Id = "81347830-2ce8-4390-9989-f5fa5cbe5546", Name = "SUNDAY SPECIAL", Srl = 14 }
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