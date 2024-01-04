using A_Domain.Repo_interfaces;
using Domain;

namespace B_DataAccess.Repos
{
    public class CourseRepository : GenericRepository<Course, int>, ICourseRepository
    {
        public CourseRepository(UniversityDbContext context) : base(context)
        {
        }
    }
}
