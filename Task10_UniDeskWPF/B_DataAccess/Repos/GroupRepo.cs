using A_Domain.Repo_interfaces;
using Task10.Models;

namespace B_DataAccess.Repos
{
    public class GroupRepo : GenericRepo<Group, int>, IGroupRepo
    {
        public GroupRepo(UniDeskDbContext context) : base(context)
        {
        }
    }
}
