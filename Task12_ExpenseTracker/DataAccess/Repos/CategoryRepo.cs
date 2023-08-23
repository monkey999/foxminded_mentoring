using Domain.Models;
using Domain.RepoInterfaces;

namespace DataAccess.Repos
{
    public class CategoryRepo : GenericRepo<Category, Guid>, ICategoryRepo
    {
        public CategoryRepo(AppDbContext context) : base(context)
        {
        }
    }
}
