using A_Domain.Repo_interfaces;

namespace B_DataAccess.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniDeskDbContext _dbContext;

        public IGroupRepo _groupRepo;
        public ICourseRepo _courseRepo;
        public IStudentRepo _studentRepo;
        public ITeacherRepo _teacherRepo;
        public ITutorRepo _tutorRepo;
        public ITutorGroupRepo _tutorGroupRepo;
        public ITeacherCourseRepo _teacherCourseRepo;

        public UnitOfWork(UniDeskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGroupRepo Groups => _groupRepo ??= new GroupRepo(_dbContext);
        public ICourseRepo Courses => _courseRepo ??= new CourseRepo(_dbContext);
        public IStudentRepo Students => _studentRepo ??= new StudentRepo(_dbContext);
        public ITeacherRepo Teachers => _teacherRepo ??= new TeacherRepo(_dbContext);
        public ITutorRepo Tutors => _tutorRepo ??= new TutorRepo(_dbContext);
        public ITutorGroupRepo TutorGroups => _tutorGroupRepo ??= new TutorGroupRepo(_dbContext);
        public ITeacherCourseRepo TeacherCourses => _teacherCourseRepo ??= new TeacherCourseRepo(_dbContext);

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
