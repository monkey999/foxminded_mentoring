using A_Domain.Repo_interfaces;
using Domain;

namespace B_DataAccess.Repos
{
    public class StudentRepository : GenericRepository<Student, int>, IStudentRepository
    {
        public StudentRepository(UniversityDbContext context) : base(context)
        {
        }
    }
}
