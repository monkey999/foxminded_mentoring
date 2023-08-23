﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230815214451_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.BaseEntities.TransactionParticipant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("TransactionParticipants");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 8, 16, 0, 44, 51, 269, DateTimeKind.Local).AddTicks(6632));

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Domain.Models.Accounts.CreditAccount", b =>
                {
                    b.HasBaseType("Domain.Models.BaseEntities.TransactionParticipant");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("CurrencyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("CreditAccounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("4bdf41e6-048a-4e70-bc2b-22033b89070d"),
                            Balance = 102.0,
                            CurrencyType = "USD",
                            Description = "weewfwef",
                            Name = "CreditAccount1"
                        },
                        new
                        {
                            Id = new Guid("579f5a24-88c4-4179-9dfc-9c4bed7658a6"),
                            Balance = 100023.2,
                            CurrencyType = "CHF",
                            Description = "cwwwecwcew",
                            Name = "CreditAccount2"
                        },
                        new
                        {
                            Id = new Guid("643c6c48-0045-4e84-97b8-9a4812b98c19"),
                            Balance = 123131.0,
                            CurrencyType = "PLZ",
                            Description = "cwewecds",
                            Name = "CreditAccount3"
                        },
                        new
                        {
                            Id = new Guid("a32567b5-76fc-4326-823e-2212b38ba5d3"),
                            Balance = 432423432.0,
                            CurrencyType = "GBP",
                            Description = "evevrve",
                            Name = "CreditAccount4"
                        },
                        new
                        {
                            Id = new Guid("49057bde-0378-48d5-bd49-b3a6fb2fa595"),
                            Balance = 321532452.0,
                            CurrencyType = "CAD",
                            Description = "cwewwfre",
                            Name = "CreditAccount5"
                        });
                });

            modelBuilder.Entity("Domain.Models.Accounts.DebitAccount", b =>
                {
                    b.HasBaseType("Domain.Models.BaseEntities.TransactionParticipant");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("CurrencyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("DebitAccounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f2eee489-44fa-4f73-808a-96e4466b65ef"),
                            Balance = 102.0,
                            CurrencyType = "USD",
                            Description = "weewfwef",
                            Name = "DebitAccount1"
                        },
                        new
                        {
                            Id = new Guid("ad24dfa8-ea1c-46b0-bdba-c4582cb2a22e"),
                            Balance = 100023.2,
                            CurrencyType = "CHF",
                            Description = "cwwwecwcew",
                            Name = "DebitAccount2"
                        },
                        new
                        {
                            Id = new Guid("384d33fa-eff3-494e-8dac-934cde251982"),
                            Balance = 432423.0,
                            CurrencyType = "PLZ",
                            Description = "cwewecds",
                            Name = "DebitAccount3"
                        },
                        new
                        {
                            Id = new Guid("81002b18-ef8f-4006-8bac-64dd6700b6bd"),
                            Balance = 12321.0,
                            CurrencyType = "GBP",
                            Description = "evevrve",
                            Name = "DebitAccount4"
                        },
                        new
                        {
                            Id = new Guid("337089f4-928a-4f31-a24e-86b43829a579"),
                            Balance = 123143.0,
                            CurrencyType = "CAD",
                            Description = "cwewwfre",
                            Name = "DebitAccount5"
                        });
                });

            modelBuilder.Entity("Domain.Models.Accounts.InvestAccount", b =>
                {
                    b.HasBaseType("Domain.Models.BaseEntities.TransactionParticipant");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("CurrencyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("InvestAccounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c91c461d-48ca-49c4-817f-f102bd2f1bee"),
                            Balance = 102.0,
                            CurrencyType = "USD",
                            Description = "weewfwef",
                            Name = "InvestAccount1"
                        },
                        new
                        {
                            Id = new Guid("fe7fd360-4232-4ea3-a6fe-d1d3c5168f8b"),
                            Balance = 31231.0,
                            CurrencyType = "CHF",
                            Description = "cwwwecwcew",
                            Name = "InvestAccount2"
                        },
                        new
                        {
                            Id = new Guid("7d6fb732-5d5f-4352-8ecd-a3ea168a09d1"),
                            Balance = 12312.0,
                            CurrencyType = "PLZ",
                            Description = "cwewecds",
                            Name = "InvestAccount3"
                        },
                        new
                        {
                            Id = new Guid("a94cb3c2-2b32-4d7c-a097-91fea0bb41f5"),
                            Balance = 242342.0,
                            CurrencyType = "GBP",
                            Description = "evevrve",
                            Name = "InvestAccount4"
                        },
                        new
                        {
                            Id = new Guid("36b5d2e9-12ea-481a-86e8-66f9dd9b542c"),
                            Balance = 12542342.0,
                            CurrencyType = "CAD",
                            Description = "cwewwfre",
                            Name = "InvestAccount5"
                        });
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.HasBaseType("Domain.Models.BaseEntities.TransactionParticipant");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("505487c1-ee03-4a57-b86a-33c95716ca40"),
                            CategoryName = "Stocks",
                            CategoryType = "Asset"
                        },
                        new
                        {
                            Id = new Guid("7df2de64-acf8-4cbf-a461-49d1c5e77424"),
                            CategoryName = "Food",
                            CategoryType = "Expense"
                        },
                        new
                        {
                            Id = new Guid("045b5038-1587-498b-a6e6-259a7ddbf0f6"),
                            CategoryName = "Salary",
                            CategoryType = "Income"
                        },
                        new
                        {
                            Id = new Guid("3fe0a406-2a1c-4462-8349-ae18deb2c136"),
                            CategoryName = "Bank loan",
                            CategoryType = "Debt"
                        },
                        new
                        {
                            Id = new Guid("06b21267-e006-4365-8d8c-acf4719324ed"),
                            CategoryName = "Crypto",
                            CategoryType = "Income"
                        });
                });

            modelBuilder.Entity("Domain.Models.Transaction", b =>
                {
                    b.HasOne("Domain.Models.BaseEntities.TransactionParticipant", "To")
                        .WithMany("TransactionsTo")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.BaseEntities.TransactionParticipant", "From")
                        .WithMany("TransactionsFrom")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("Domain.Models.Accounts.CreditAccount", b =>
                {
                    b.HasOne("Domain.Models.BaseEntities.TransactionParticipant", null)
                        .WithOne()
                        .HasForeignKey("Domain.Models.Accounts.CreditAccount", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Accounts.DebitAccount", b =>
                {
                    b.HasOne("Domain.Models.BaseEntities.TransactionParticipant", null)
                        .WithOne()
                        .HasForeignKey("Domain.Models.Accounts.DebitAccount", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Accounts.InvestAccount", b =>
                {
                    b.HasOne("Domain.Models.BaseEntities.TransactionParticipant", null)
                        .WithOne()
                        .HasForeignKey("Domain.Models.Accounts.InvestAccount", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.HasOne("Domain.Models.BaseEntities.TransactionParticipant", null)
                        .WithOne()
                        .HasForeignKey("Domain.Models.Category", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.BaseEntities.TransactionParticipant", b =>
                {
                    b.Navigation("TransactionsFrom");

                    b.Navigation("TransactionsTo");
                });
#pragma warning restore 612, 618
        }
    }
}