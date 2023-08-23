using A_Domain.Models;
using A_Domain.Repo_interfaces;

namespace B_DataAccess.Repos
{
    public class TeacherCourseRepo : GenericRepo<TeacherCourse, int>, ITeacherCourseRepo
    {
        public TeacherCourseRepo(UniDeskDbContext context) : base(context)
        {
        }
    }
}
