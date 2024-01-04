using DataAccess;
using Logic;

namespace Task12_ExpenseTracker.StartupInstaller
{
    public static partial class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.RegisterDLServices(configuration);

            services.RegisterBLServices();

            return services;
        }
    }
}
