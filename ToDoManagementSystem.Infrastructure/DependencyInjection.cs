using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoManagementSystem.Application.Interfaces.Security;
using ToDoManagementSystem.Infrastructure.Configuration;
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
            return services;
        }
    }
}
