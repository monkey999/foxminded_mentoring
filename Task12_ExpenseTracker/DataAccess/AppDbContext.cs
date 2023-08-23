using Domain.Enums;
using Domain.Models;
using Domain.Models.Accounts;
using Domain.Models.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CreditAccount> CreditAccounts { get; set; }
        public DbSet<DebitAccount> DebitAccounts { get; set; }
        public DbSet<DebtAccount> DebtAccounts { get; set; }
        public DbSet<InvestAccount> InvestAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionParticipant> TransactionParticipants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ExpenseTrackerDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<CreditAccount>().ToTable("CreditAccounts");
            modelBuilder.Entity<DebitAccount>().ToTable("DebitAccounts");
            modelBuilder.Entity<DebtAccount>().ToTable("DebtAccounts");
            modelBuilder.Entity<InvestAccount>().ToTable("InvestAccounts");

            modelBuilder.Entity<Category>().Property(c => c.CategoryType).HasConversion<string>();
            modelBuilder.Entity<CreditAccount>().Property(c => c.CurrencyType).HasConversion<string>();
            modelBuilder.Entity<DebitAccount>().Property(c => c.CurrencyType).HasConversion<string>();
            modelBuilder.Entity<DebtAccount>().Property(c => c.CurrencyType).HasConversion<string>();
            modelBuilder.Entity<DebtAccount>().Property(c => c.DebtAccountType).HasConversion<string>();
            modelBuilder.Entity<InvestAccount>().Property(c => c.CurrencyType).HasConversion<string>();

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryName = "Coca plantation", CategoryType = CategoryType.Income },
                new Category { CategoryName = "Soderzhanka", CategoryType = CategoryType.Expense },
                new Category { CategoryName = "Weapons", CategoryType = CategoryType.Income },
                new Category { CategoryName = "Cocaine", CategoryType = CategoryType.Expense },
                new Category { CategoryName = "Trading slaves", CategoryType = CategoryType.Income }
                );

            modelBuilder.Entity<CreditAccount>().HasData(
                new CreditAccount("CreditAccount1", "weewfwef", 102, CurrencyType.USD),
                new CreditAccount("CreditAccount2", "cwwwecwcew", 100023.2, CurrencyType.CHF),
                new CreditAccount("CreditAccount3", "cwewecds", 123131, CurrencyType.PLZ),
                new CreditAccount("CreditAccount4", "evevrve", 432423432, CurrencyType.GBP),
                new CreditAccount("CreditAccount5", "cwewwfre", 321532452, CurrencyType.CAD)
                );

            modelBuilder.Entity<DebitAccount>().HasData(
                new DebitAccount("DebitAccount1", "weewfwef", 102, CurrencyType.USD),
                new DebitAccount("DebitAccount2", "cwwwecwcew", 100023.2, CurrencyType.CHF),
                new DebitAccount("DebitAccount3", "cwewecds", 432423, CurrencyType.PLZ),
                new DebitAccount("DebitAccount4", "evevrve", 12321, CurrencyType.GBP),
                new DebitAccount("DebitAccount5", "cwewwfre", 123143, CurrencyType.CAD)
                );

            modelBuilder.Entity<DebtAccount>().HasData(
                new DebtAccount("DebtAccount1", "weewfwef", 102, CurrencyType.USD, DebtAccountType.IDebtGiver),
                new DebtAccount("DebtAccount2", "cwwwecwcew", 100023.2, CurrencyType.CHF, DebtAccountType.IDebtTaker),
                new DebtAccount("DebtAccount3", "cwewecds", 432423, CurrencyType.PLZ, DebtAccountType.IDebtGiver),
                new DebtAccount("DebtAccount4", "evevrve", 12321, CurrencyType.GBP, DebtAccountType.IDebtGiver),
                new DebtAccount("DebtAccount5", "cwewwfre", 123143, CurrencyType.CAD, DebtAccountType.IDebtGiver)
                );

            modelBuilder.Entity<InvestAccount>().HasData(
                new InvestAccount("InvestAccount1", "weewfwef", 102, CurrencyType.USD),
                new InvestAccount("InvestAccount2", "cwwwecwcew", 31231, CurrencyType.CHF),
                new InvestAccount("InvestAccount3", "cwewecds", 12312, CurrencyType.PLZ),
                new InvestAccount("InvestAccount4", "evevrve", 242342, CurrencyType.GBP),
                new InvestAccount("InvestAccount5", "cwewwfre", 12542342, CurrencyType.CAD)
                 );

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(t => t.TransactionType).HasConversion<string>();
                entity.Property(c => c.Date).HasDefaultValue(DateTime.Now);
                entity.Property(c => c.Amount).HasDefaultValue(0);

                entity.HasOne(t => t.From)
                    .WithMany(tp => tp.TransactionsFrom)
                    .HasForeignKey(t => t.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.To)
                    .WithMany(tp => tp.TransactionsTo)
                    .HasForeignKey(t => t.ReceiverId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { Amount = 234234, SenderId = Guid.NewGuid(), ReceiverId = Guid.NewGuid(), TransactionType = TransactionType.Income },
                new Transaction { Amount = 2342423, SenderId = Guid.NewGuid(), ReceiverId = Guid.NewGuid(), TransactionType = TransactionType.IGiveLoan },
                new Transaction { Amount = 54343, SenderId = Guid.NewGuid(), ReceiverId = Guid.NewGuid(), TransactionType = TransactionType.RepaysMeLoan },
                new Transaction { Amount = 2342323, SenderId = Guid.NewGuid(), ReceiverId = Guid.NewGuid(), TransactionType = TransactionType.Expense },
                new Transaction { Amount = 12545, SenderId = Guid.NewGuid(), ReceiverId = Guid.NewGuid(), TransactionType = TransactionType.Income }
            );
        }
    }
}
