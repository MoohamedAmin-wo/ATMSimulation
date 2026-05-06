using ATMSimulation.Application.Abstraction;
using ATMSimulation.Infrastructure.Persistence;
using ATMSimulation.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ATMSimulation.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services , IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("DefaultConnection") 
            ?? throw new NullReferenceException("no connection strings found !");

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection)) ;
        services.AddScoped<IEncryptionService , EncryptionService>();

        return services;
    }
}
