using Domain.Models;
using System.Linq.Expressions;

namespace DataAccess.Specifications.CategorySpecs
{
    public class CategoryGetAllSpecification : BaseSpecification<Category>
    {
        public CategoryGetAllSpecification()
        {
        }

        public CategoryGetAllSpecification(Expression<Func<Category, bool>> criteria)
            : base(criteria)
        {
            AddOrderBy(x => x.Id);
        }
    }
}
