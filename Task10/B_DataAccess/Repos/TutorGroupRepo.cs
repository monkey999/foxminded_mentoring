using A_Domain.Models;
using A_Domain.Repo_interfaces;

namespace B_DataAccess.Repos
{
    public class TutorGroupRepo : GenericRepo<TutorGroup, int>, ITutorGroupRepo
    {
        public TutorGroupRepo(UniDeskDbContext context) : base(context)
        {
        }
    }
}
