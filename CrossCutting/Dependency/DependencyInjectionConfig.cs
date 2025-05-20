
using Application.Services;
using Data.Repository;
using Domain.Interfaces.Repositorys;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;


namespace CrossCutting.Dependency

{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserRepostory, UserRepository>();
            services.AddScoped<IObjectiveRepostory, ObjectEntityRepository>();
            services.AddScoped<ITaskRepository, TaskEntityRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IObjectiveService, ObjectiveService>();        
        }
    }
}
