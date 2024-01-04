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
        public DbSet<DebitAccount> DebitAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionParticipant> TransactionParticipants { get; set; }
        public DbSet<AccountBase> AccountBases { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.CategoryType).HasConversion<string>();
            modelBuilder.Entity<DebitAccount>().Property(c => c.CurrencyType).HasConversion<string>();
            modelBuilder.Entity<AccountBase>().Property(c => c.CurrencyType).HasConversion<string>();

            modelBuilder.Entity<TransactionParticipant>().ToTable("TransactionParticipants");
            modelBuilder.Entity<AccountBase>().ToTable("AccountBases");
            modelBuilder.Entity<DebitAccount>().ToTable("DebitAccounts");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryName = "Coca plantation", CategoryType = CategoryType.Income },
                new Category { CategoryName = "Soderzhanka", CategoryType = CategoryType.Expense },
                new Category { CategoryName = "Weapons", CategoryType = CategoryType.Income },
                new Category { CategoryName = "Cocaine", CategoryType = CategoryType.Expense },
                new Category { CategoryName = "Trading slaves", CategoryType = CategoryType.Income }
                );

            modelBuilder.Entity<DebitAccount>().HasData(
                new DebitAccount("DebitAccount1", "weewfwef", 102, CurrencyType.USD, 0, 1000),
                new DebitAccount("DebitAccount2", "cwwwecwcew", 100023.2, CurrencyType.CHF, 500, 1000),
                new DebitAccount("DebitAccount3", "cwewecds", 432423, CurrencyType.PLZ, 1000, 1000),
                new DebitAccount("DebitAccount4", "evevrve", 12321, CurrencyType.GBP, 200, 1000),
                new DebitAccount("DebitAccount5", "cwewwfre", 123143, CurrencyType.CAD, 300, 1000)
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
        }
    }
}
