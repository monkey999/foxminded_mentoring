using A_Domain.Repo_interfaces;
using System.Threading.Tasks;

namespace B_DataAccess.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityDbContext _dbContext;
        public IStudentRepository _studentRepo;
        public ICourseRepository _courseRepo;
        public IGroupRepository _groupRepo;

        public UnitOfWork(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IStudentRepository Students => _studentRepo ??= new StudentRepository(_dbContext);
        public ICourseRepository Courses => _courseRepo ??= new CourseRepository(_dbContext);
        public IGroupRepository Groups => _groupRepo ??= new GroupRepository(_dbContext);

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
