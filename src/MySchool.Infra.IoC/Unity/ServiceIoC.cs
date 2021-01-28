using Microsoft.Extensions.DependencyInjection;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infra.Data.Repositories;
using MySchool.Infra.Data.Repositories.Context;
using MySchool.Infra.Data.Repositories.Transactions;

namespace MySchool.Infra.IoC.Unity
{
    public static class ServiceIoC
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<MySchoolContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositorySchool, RepositorySchool>();
        }
    }
}
