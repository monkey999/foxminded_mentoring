using A_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Task10.Models;

namespace B_DataAccess
{
    public class UniDeskDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TutorGroup> TutorGroups { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<Tutor> Tutors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=UniDeskWPF;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tutor>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(t => t.TeacherId).IsRequired(false);
                entity.HasOne(t => t.Teacher)
                    .WithOne(t => t.Tutor)
                    .HasForeignKey<Tutor>(t => t.TeacherId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(t => t.TutorGroups)
                    .WithOne(tg => tg.Tutor)
                    .HasForeignKey(tg => tg.TutorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(t => t.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(t => t.LastName).HasMaxLength(50).IsRequired();
                entity.HasOne(t => t.Tutor)
                    .WithOne(t => t.Teacher)
                    .HasForeignKey<Tutor>(t => t.TeacherId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(t => t.TeacherCourses)
                    .WithOne(tc => tc.Teacher)
                    .HasForeignKey(tc => tc.TeacherId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).HasMaxLength(50).IsRequired();
                entity.Property(c => c.Description).HasMaxLength(255);
                entity.HasMany(c => c.Groups)
                    .WithOne(g => g.Course)
                    .HasForeignKey(g => g.CourseId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(t => t.TeacherCourses)
                    .WithOne(crc=> crc.Course)
                    .HasForeignKey(crc => crc.CourseId)
                    .IsRequired(false)
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
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(g => g.Students)
                    .WithOne(s => s.Group)
                    .HasForeignKey(s => s.GroupId)
                    .IsRequired(false)
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
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TutorGroup>().HasKey(sc => new { sc.TutorId, sc.GroupId });

            modelBuilder.Entity<TeacherCourse>().HasKey(sc => new { sc.CourseId, sc.TeacherId });

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "C#/.NET", Description = "This course will teach you how to create phishing software" },
                new Course { Id = 2, Name = "SQL", Description = "This course will teach you how to use SQL injections" },
                new Course { Id = 3, Name = "Algorithms and Data Structures", Description = "This course will teach you how to bruteforce passwords" },
                new Course { Id = 4, Name = "Networks", Description = "Learn cross-site scripting, port scanning, buffer overflow, etc." },
                new Course { Id = 5, Name = "OS architecture", Description = "Create your rootkit" });

            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, CourseId = 1, Name = "SR-01" },
                new Group { Id = 2, CourseId = 4, Name = "SR-02" },
                new Group { Id = 3, CourseId = 3, Name = "FR-01" },
                new Group { Id = 4, CourseId = 3, Name = "FR-02" },
                new Group { Id = 5, CourseId = 2, Name = "SR-01" });

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, FirstName = "John", LastName = "Doe" },
                new Teacher { Id = 2, FirstName = "Jane", LastName = "Smith" },
                new Teacher { Id = 3, FirstName = "Ivan", LastName = "Ivanov" },
                new Teacher { Id = 4, FirstName = "Petr", LastName = "Petrov" },
                new Teacher { Id = 5, FirstName = "Michael", LastName = "Michaelson" });

            modelBuilder.Entity<Tutor>().HasData(
                new Tutor { Id = 1, TeacherId = 1 },
                new Tutor { Id = 2, TeacherId = 2 },
                new Tutor { Id = 3, TeacherId = 3 },
                new Tutor { Id = 4, TeacherId = 4 },
                new Tutor { Id = 5, TeacherId = 5 });


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


            var tutorGroups = new List<TutorGroup>();

            for (int tutorId = 1; tutorId <= 5; tutorId++)
            {
                for (int groupId = 1; groupId <= 5; groupId++)
                {
                    if (!tutorGroups.Any(tc => tc.TutorId == tutorId && tc.GroupId == groupId))
                    {
                        tutorGroups.Add(new TutorGroup { TutorId = tutorId, GroupId = groupId });
                    }
                }
            }

            modelBuilder.Entity<TutorGroup>().HasData(tutorGroups);

            var teacherCourses = new List<TeacherCourse>();

            for (int courseId = 1; courseId <= 5; courseId++)
            {
                for (int teacherId = 1; teacherId <= 5; teacherId++)
                {
                    if (!teacherCourses.Any(tc => tc.CourseId == courseId && tc.TeacherId == teacherId))
                    {
                        teacherCourses.Add(new TeacherCourse { CourseId = courseId, TeacherId = teacherId });
                    }
                }
            }

            modelBuilder.Entity<TeacherCourse>().HasData(teacherCourses);
        }
    }
}
