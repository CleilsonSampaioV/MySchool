using Microsoft.Extensions.DependencyInjection;
using MySchool.Infra.Data.Repositories.Context;
using MySchool.Infra.Data.Repositories.Transactions;

namespace MySchool.Infra.IoC.Unity
{
    public static class ServiceIoC
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            ////////// Application
            //services.AddTransient<ICartolaFcService, CartolaFcService>();
            //services.AddTransient<IAtletaService, AtletaService>();
            //services.AddTransient<IMercadoService, MercadoService>();
            //services.AddTransient<IMercadoTimeService, MercadoTimeService>();
            //services.AddTransient<IUsuarioService, UsuarioService>();
            //services.AddTransient<ICartoleiroService, CartoleiroService>();
            //services.AddTransient<IEmpresaService, EmpresaService>();
            //services.AddTransient<IMercadoAtletasPontuacaoService, MercadoAtletasPontuacaoService>();
            //services.AddTransient<IRelatorioService, RelatorioService>();

            // Infra - Data
            services.AddScoped<MySchoolContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<IAtletaRepository, AtletaRepository>();
            

        }
    }
}
