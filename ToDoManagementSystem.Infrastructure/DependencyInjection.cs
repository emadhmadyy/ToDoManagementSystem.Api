using Microsoft.Extensions.DependencyInjection;
using ToDoManagementSystem.Application.Interfaces.Security;
using ToDoManagementSystem.Infrastructure.Security;

namespace ToDoManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
            return services;
        }
    }
}
