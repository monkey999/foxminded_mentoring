using A_Domain.Repo_interfaces;
using B_DataAccess;
using B_DataAccess.Repos;
using C_Logic.Service_interfaces;
using C_Logic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Task9.Installers
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
        }

        public static void ConfigureScopedCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
