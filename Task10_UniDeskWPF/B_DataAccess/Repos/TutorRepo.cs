using A_Domain.Repo_interfaces;
using Task10.Models;

namespace B_DataAccess.Repos
{
    public class TutorRepo : GenericRepo<Tutor, int>, ITutorRepo
    {
        public TutorRepo(UniDeskDbContext context) : base(context)
        {
        }
    }
}
