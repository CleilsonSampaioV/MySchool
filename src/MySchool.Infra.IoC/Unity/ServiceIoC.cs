using Microsoft.Extensions.DependencyInjection;
using MySchool.Domain.Handlers;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Domain.Queries;
using MySchool.Infra.Data.Repositories;
using MySchool.Infra.Data.Repositories.Context;
using MySchool.Infra.Data.Repositories.Transactions;

namespace MySchool.Infra.IoC.Unity
{
    public static class ServiceIoC
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Context
            services.AddScoped<MySchoolContext>();

            //Unit of Work
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Hendler
            services.AddTransient<ClassHandler, ClassHandler>();
            services.AddTransient<SchoolHandler, SchoolHandler>();

            //Repository Queries
            services.AddTransient<ClassQueries>();
            services.AddTransient<SchoolQueries>();

            //Repository
            services.AddTransient<IRepositorySchool, RepositorySchool>();
            services.AddTransient<IRepositoryClass, RepositoryClass>();

        }
    }
}
