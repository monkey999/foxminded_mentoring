using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace B_DataAccess
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=UniversityMVC;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).HasMaxLength(50).IsRequired();
                entity.Property(c => c.Description).HasMaxLength(255);
                entity.HasMany(c => c.Groups)
                    .WithOne(g => g.Course)
                    .HasForeignKey(g => g.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Id).ValueGeneratedOnAdd();
                entity.Property(g => g.Name).HasMaxLength(50).IsRequired();
                entity.HasOne(g => g.Course)
                    .WithMany(c => c.Groups)
                    .HasForeignKey(g => g.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(g => g.Students)
                    .WithOne(s => s.Group)
                    .HasForeignKey(s => s.GroupId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id).ValueGeneratedOnAdd();
                entity.Property(s => s.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(s => s.LastName).HasMaxLength(50).IsRequired();
                entity.HasOne(s => s.Group)
                    .WithMany(g => g.Students)
                    .HasForeignKey(s => s.GroupId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "C#/.NET", Description = "This course will teach you how to create phishing software" },
                new Course { Id = 2, Name = "SQL", Description = "This course will teach you how to use SQL injections" },
                new Course { Id = 3, Name = "Algorithms and Data Structures", Description = "This course will teach you how to bruteforce passwords" },
                new Course { Id = 4, Name = "Networks", Description = "Learn cross-site scripting, port scanning, buffer overflow, etc." },
                new Course { Id = 5, Name = "OS architecture", Description = "Create your rootkit" });

            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, CourseId = 1, Name = "SR-01" },
                new Group { Id = 2, CourseId = 4, Name = "SR-02" },
                new Group { Id = 3, CourseId = 3, Name = "FR-01"},
                new Group { Id = 4, CourseId = 3, Name = "FR-02" },
                new Group { Id = 5, CourseId = 2, Name = "SR-01" });

            var names = new[] { "John", "Sarah", "David", "Emily", "Michael", "Olivia", "William", "Sophia", "James", "Emma" };
            var surnames = new[] { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };

            var random = new Random();
            var students = Enumerable.Range(1, 100).Select(i =>
            {
                var firstName = names[random.Next(names.Length)];
                var lastName = surnames[random.Next(surnames.Length)];
                var groupId = random.Next(1, 6);
                return new Student { Id = i, FirstName = firstName, LastName = lastName, GroupId = groupId };
            }).ToList();

            modelBuilder.Entity<Student>().HasData(students);
        }
    }
}
