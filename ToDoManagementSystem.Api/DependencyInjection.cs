using ToDoManagementSystem.Application;
using ToDoManagementSystem.Infrastructure;
using ToDoManagementSystem.Api.Middlewares;


namespace ToDoManagementSystem.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ExceptionHandlingMiddleware>();

            services.AddApplicationDI().AddInfrastructureDI(configuration);
            return services;
        }
    }
}
