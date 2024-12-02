using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using TestWebBackEndDeveloper.Application.UnitOfWork;
using TestWebBackEndDeveloper.Extensions.SwaggerDocumentation;
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
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Teste backend: sistema Financeiro",
                    Description = @"
                        O desafio é criar um sistema financeiro com as seguintes funcionalidades:
                        - **Gerenciamento de depósitos, compras e vendas de Bitcoin.**
                        - **Autenticação JWT**: Permitir cadastro e login de usuários.
                        - **Consulta de saldo**: Visualizar o saldo disponível.
                        - **Cotação em tempo real**: Exibir cotações atualizadas de Bitcoin.
                        - **Posição de investimentos**: Mostrar o status das operações realizadas.
                        - **Transações com notificações**: Envio de notificações por e-mail para operações de depósito e venda.
                        - **Histórico de cotações e relatórios**: Permitir consulta de operações com intervalos customizáveis.

                        ### Base de Dados
                        A aplicação deve suportar:
                        - **MariaDB**
                        - **PostgreSQL**
                        - **MongoDB**

                        Para mais informações, consulte o repositório oficial:
                        [GitHub - TestWebBackEndDeveloper](https://github.com/PedroPucci/TestWebBackEndDeveloper).
                        ",
                });

                opt.OperationFilter<CustomOperationDescriptions>();
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