using ToDoManagementSystem.Application;
using ToDoManagementSystem.Infrastructure;

namespace ToDoManagementSystem.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddApplicationDI().AddInfrastructureDI();
            return services;
        }
    }
}
