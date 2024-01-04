using A_Domain.Repo_interfaces;
using Task10.Models;

namespace B_DataAccess.Repos
{
    public class CourseRepo : GenericRepo<Course, int>, ICourseRepo
    {
        public CourseRepo(UniDeskDbContext context) : base(context)
        {
        }
    }
}
