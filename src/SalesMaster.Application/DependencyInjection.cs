using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesMaster.Application.Domain.Interfaces;
using SalesMaster.Application.Domain.Repositories;
using SalesMaster.Application.Infraestructure.Persistance;
using System.Reflection;

namespace SalesMaster.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SalesMasterDbContext>(options =>
                   options.UseNpgsql(connectionString));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        return services;
    }
}
    