using System;
using System.Threading.Tasks;

namespace A_Domain.Repo_interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGroupRepository Groups { get; }
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }

        Task SaveAsync();
    }
}
