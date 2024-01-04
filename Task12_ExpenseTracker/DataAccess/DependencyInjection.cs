using DataAccess.Repos;
using Domain.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(IGenericRepo<,>), typeof(GenericRepo<,>));
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IDebitAccountRepo, DebitAccountRepo>();
            services.AddScoped<ITransactionRepo, TransactionRepo>();
            services.AddScoped<ITransactionParticipantRepo, TransactionParticipantRepo>();
            services.AddScoped<IAccountBaseRepo, AccountBaseRepo>();
            services.AddScoped<IUnitOfWOrk, UnitOfWork>();

            return services;
        }
    }
}
