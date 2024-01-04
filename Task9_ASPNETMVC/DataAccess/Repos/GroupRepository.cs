using A_Domain.Repo_interfaces;
using Domain;

namespace B_DataAccess.Repos
{
    public class GroupRepository : GenericRepository<Group, int>, IGroupRepository
    {
        public GroupRepository(UniversityDbContext context) : base(context)
        {
        }
    }
}
