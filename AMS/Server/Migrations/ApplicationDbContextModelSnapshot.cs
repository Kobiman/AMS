﻿// <auto-generated />
using System;
using AMS.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AMS.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AMS.Shared.Account", b =>
                {
                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AMS.Shared.AccountTransaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Credit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Debit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountTransactions");
                });

            modelBuilder.Entity("AMS.Shared.Agent", b =>
                {
                    b.Property<string>("AgentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("ApprovedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Commission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgentId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("AMS.Shared.AgentExpense", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AgentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgentExpenses");
                });

            modelBuilder.Entity("AMS.Shared.Audit", b =>
                {
                    b.Property<int>("AuditID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuditID"), 1L, 1);

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControllerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageAccessed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeAccessed")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuditID");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("AMS.Shared.Debtors", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AgentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Debt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Debtors");
                });

            modelBuilder.Entity("AMS.Shared.Expense", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("AMS.Shared.Game", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Commission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Srl")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = "4e3cf598-796e-43ae-9cbd-a1dd9a6404f2",
                            Commission = 0m,
                            Name = "MONDAY SPECIAL",
                            Srl = 1
                        },
                        new
                        {
                            Id = "ead1d20d-1335-4c88-bc46-2c06402621d0",
                            Commission = 0m,
                            Name = "PIONEER",
                            Srl = 2
                        },
                        new
                        {
                            Id = "0b4e2f14-72b8-4637-a27d-df96b3c9de7d",
                            Commission = 0m,
                            Name = "LUCKY TUESDAY",
                            Srl = 3
                        },
                        new
                        {
                            Id = "2e76359c-a143-4689-95fa-8d6e00402b99",
                            Commission = 0m,
                            Name = "VAG EAST",
                            Srl = 4
                        },
                        new
                        {
                            Id = "6be243f4-98cb-49eb-8329-e7929acbbe58",
                            Commission = 0m,
                            Name = "MID-WEEK",
                            Srl = 5
                        },
                        new
                        {
                            Id = "4fbf32b2-a201-40f3-ae2a-54ad56dab0ba",
                            Commission = 0m,
                            Name = "VAG WEST",
                            Srl = 6
                        },
                        new
                        {
                            Id = "596529e9-b5f5-4741-a560-f620d201d9de",
                            Commission = 0m,
                            Name = "FORTUNE THURSDAY",
                            Srl = 7
                        },
                        new
                        {
                            Id = "08bb2037-b34a-45e7-a928-fa4978c20320",
                            Commission = 0m,
                            Name = "AFRICA",
                            Srl = 8
                        },
                        new
                        {
                            Id = "a7c6d1fa-0715-4f47-b691-ef466c0e4c9e",
                            Commission = 0m,
                            Name = "FRIDAY BONANZA",
                            Srl = 9
                        },
                        new
                        {
                            Id = "b4ef3086-688b-4985-957b-05e815f42ef2",
                            Commission = 0m,
                            Name = "OBIRI",
                            Srl = 10
                        },
                        new
                        {
                            Id = "0bdb1c9e-6383-4e70-baf5-4937cd2ac8da",
                            Commission = 0m,
                            Name = "NATIONAL",
                            Srl = 11
                        },
                        new
                        {
                            Id = "376ecf06-b3ba-4d9c-adc3-dccf3c8884ab",
                            Commission = 0m,
                            Name = "OLD SOLDIER",
                            Srl = 12
                        },
                        new
                        {
                            Id = "c01879f3-23c2-4904-b258-b84611eaf859",
                            Commission = 0m,
                            Name = "ASEDA",
                            Srl = 13
                        },
                        new
                        {
                            Id = "fb359d48-dccf-410f-8e76-01ebfcc72ed7",
                            Commission = 0m,
                            Name = "SUNDAY SPECIAL",
                            Srl = 14
                        });
                });

            modelBuilder.Entity("AMS.Shared.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LocationABV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("AMS.Shared.Payout", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AgentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("ApprovedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AreaOfOperations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChequeNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<decimal>("PayinAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PayoutAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ReceivedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceivedFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payouts");
                });

            modelBuilder.Entity("AMS.Shared.Sales", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("AreaOfOperations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DailySales")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DrawDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GameId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GrossSales")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfBooks")
                        .HasColumnType("int");

                    b.Property<string>("ReceiptNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesApprovedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SalesCommission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SalesStaffId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesTreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sheet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WinAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WinsApprovedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WinsStaffId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WinsTreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("AMS.Shared.Transfer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("AMS.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AMS.Shared.AccountTransaction", b =>
                {
                    b.HasOne("AMS.Shared.Account", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AMS.Shared.Sales", b =>
                {
                    b.HasOne("AMS.Shared.Agent", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AMS.Shared.Account", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("AMS.Shared.Agent", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
