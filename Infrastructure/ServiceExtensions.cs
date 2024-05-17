using Domain.Repositories;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TrafficContext>(options => options.UseSqlServer(configuration.GetConnectionString("TrafficContext")));

        services.AddScoped<ITrafficEventRepository, TrafficEventRepository>();
        services.AddScoped<ITrafficRepository, TrafficRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
