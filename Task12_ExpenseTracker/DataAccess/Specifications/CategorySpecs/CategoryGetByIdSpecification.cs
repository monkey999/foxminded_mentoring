using Domain.Models;
using System.Linq.Expressions;

namespace DataAccess.Specifications.CategorySpecs
{
    public class CategoryGetByIdSpecification : BaseSpecification<Category>
    {
        public CategoryGetByIdSpecification()
        {
        }

        public CategoryGetByIdSpecification(Expression<Func<Category, bool>> criteria)
            : base(criteria)
        {
        }
    }
}
