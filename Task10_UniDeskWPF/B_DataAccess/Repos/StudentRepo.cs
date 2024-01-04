using A_Domain.Repo_interfaces;
using Task10.Models;

namespace B_DataAccess.Repos
{
    public class StudentRepo : GenericRepo<Student, int>, IStudentRepo
    {
        public StudentRepo(UniDeskDbContext context) : base(context)
        {
        }
    }
}
