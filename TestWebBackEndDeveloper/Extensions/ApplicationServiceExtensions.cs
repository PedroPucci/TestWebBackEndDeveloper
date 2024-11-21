using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using TestWebBackEndDeveloper.Application.UnitOfWork;
using TestWebBackEndDeveloper.Infrastracture.Connection;
using TestWebBackEndDeveloper.Infrastracture.Repository.RepositoryUoW;

namespace TestWebBackEndDeveloper.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Teste para vaga desenvolvedor backend",
                    Description = "Teste para seleção",
                });
            }
            );
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseNpgsql(config.GetConnectionString("WebApiDatabase"));
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200");
                });
            });

            services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
            services.AddScoped<IRepositoryUoW, RepositoryUoW>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition
                                   = JsonIgnoreCondition.WhenWritingNull;
            });

            return services;
        }
    }
}