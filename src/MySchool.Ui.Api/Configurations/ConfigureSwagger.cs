using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace MySchool.Ui.Api.Configurations
{
    public static class ConfigureSwagger
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MySchool Project",
                    Description = "MySchool API Swagger surface",
                    Contact = new OpenApiContact { Name = "Cleilson Sampaio", Email = "jcleilsonsv@hotmail.com", Url = new Uri("https://github.com/CleilsonSampaioV/MySchool") },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("") }
                });
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Equinox Project");
            });
        }
    }
}
