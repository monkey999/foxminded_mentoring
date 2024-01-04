using Logic.Mapping_Profiles;
using Logic.ServiceInterfaces;
using Logic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterBLServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDebitAccountService, DebitAccountService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionProcessor, TransactionProcessor>();
            services.AddScoped<Validator>();

            services.AddAutoMapper(typeof(CategoryMappingProfile), typeof(DebitAccountMappingProfile),
                typeof(TransactionMappingProfile));

            return services;
        }
    }
}
