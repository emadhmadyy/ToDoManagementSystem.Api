using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ToDoManagementSystem.Application.Interfaces.Repositories;
using ToDoManagementSystem.Application.Interfaces.Security;
using ToDoManagementSystem.Infrastructure.Configuration;
using ToDoManagementSystem.Infrastructure.Mongo;
using ToDoManagementSystem.Infrastructure.Repositories;
using ToDoManagementSystem.Infrastructure.Security;

namespace ToDoManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            MongoDbClassMappings.Register();
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>()
                    ?? throw new InvalidOperationException("MongoDbSettings section is missing in configuration.");

                return new MongoClient(settings.ConnectionString);
            });
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
