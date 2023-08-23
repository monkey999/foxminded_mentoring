using DataAccess;
using DataAccess.Repos;
using Domain.RepoInterfaces;
using Logic.Mapping_Profiles;
using Logic.ServiceInterfaces;
using Logic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Task12_ExpenseTracker.StartupInstaller
{
    public static partial class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            RegisterSwagger(services);

            RegisterCustomDependencies(services);

            return services;
        }

        private static void RegisterCustomDependencies(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            services.AddAutoMapper(typeof(CategoryMappingProfile), typeof(CreditAccountMappingProfile), typeof(DebitAccountMappingProfile), typeof(DebtAccountMappingProfile),
                typeof(InvestAccountMappingProfile), typeof(ReportMappingProfile), typeof(TransactionMappingProfile));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepo<,>), typeof(GenericRepo<,>));

            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ICreditAccountRepo, CreditAccountRepo>();
            services.AddScoped<IDebitAccountRepo, DebitAccountRepo>();
            services.AddScoped<IDebtAccountRepo, DebtAccountRepo>();
            services.AddScoped<IInvestAccountRepo, InvestAccountRepo>();
            services.AddScoped<ITransactionRepo, TransactionRepo>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICreditAccountService, CreditAccountService>();
            services.AddScoped<IDebitAccountService, DebitAccountService>();
            services.AddScoped<IDebtAccountService, DebtAccountService>();
            services.AddScoped<IInvestAccountService, InvestAccountService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionProcessor, TransactionProcessor>();
        }

        private static void RegisterSwagger(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
