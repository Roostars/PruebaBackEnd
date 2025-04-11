using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {        
        var connectionString = "Data Source=appdatabase.db";
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));

             services.AddTransient<IEventRepository, EventRepository>();

        return services;
    }
}