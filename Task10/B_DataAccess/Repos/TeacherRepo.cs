using A_Domain.Repo_interfaces;
using Task10.Models;

namespace B_DataAccess.Repos
{
    public class TeacherRepo : GenericRepo<Teacher, int>, ITeacherRepo
    {
        public TeacherRepo(UniDeskDbContext context) : base(context)
        {
        }
    }
}
