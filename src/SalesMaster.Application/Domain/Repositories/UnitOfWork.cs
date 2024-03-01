using SalesMaster.Application.Domain.Interfaces;
using SalesMaster.Application.Infraestructure.Persistance;

namespace SalesMaster.Application.Domain.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IEmployeeRepository Employees { get; }
    public IRoleRepository Roles { get; }
    private readonly SalesMasterDbContext _context;

    public UnitOfWork(SalesMasterDbContext context, IEmployeeRepository employee, IRoleRepository roles)
    {
        _context = context;
        Employees = employee;
        Roles = roles;
    }

    public async Task<int> SaveChanges()
    {   
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
