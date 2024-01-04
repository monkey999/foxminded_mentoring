using Domain.Models;
using System.Linq.Expressions;

namespace DataAccess.Specifications.CategorySpecs
{
    public class CategoryGetByIdAsNoTrackingSpecification : BaseSpecification<Category>
    {
        public CategoryGetByIdAsNoTrackingSpecification()
        {
        }

        public CategoryGetByIdAsNoTrackingSpecification(Expression<Func<Category, bool>> criteria)
            : base(criteria)
        {
            ApplyAsNoTracking(true);
        }
    }
}
