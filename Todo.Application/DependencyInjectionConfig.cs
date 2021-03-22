namespace Todo.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using Todo.Repository.Adapter;

    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddApplicationDependencies(
            this IServiceCollection services)
        {
            services.AddSingleton<ITodoRepository, TodoRepository>();
            services.AddScoped<ITodoService, TodoService>();

            return services;
        }
    }
}
