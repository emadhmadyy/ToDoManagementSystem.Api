using Microsoft.Extensions.DependencyInjection;
using ToDoManagementSystem.Application.Interfaces.Services;
using ToDoManagementSystem.Application.Services;

namespace ToDoManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI (this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITodoService, TodoService>();
            return services;
        }
    }
}
