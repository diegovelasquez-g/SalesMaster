using Microsoft.EntityFrameworkCore;
using SalesMaster.Application.Domain.Entities;

namespace SalesMaster.Application.Infraestructure.Persistance;

public class SalesMasterDbContext : DbContext
{
    public SalesMasterDbContext()
    {
    }

    public SalesMasterDbContext(DbContextOptions<SalesMasterDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Stock> Stocks { get; set; }
}
