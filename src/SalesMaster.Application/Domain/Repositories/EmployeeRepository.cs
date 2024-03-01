using Microsoft.EntityFrameworkCore;
using SalesMaster.Application.Domain.Entities;
using SalesMaster.Application.Domain.Interfaces;
using SalesMaster.Application.Infraestructure.Persistance;

namespace SalesMaster.Application.Domain.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(SalesMasterDbContext context) : base(context)
    {
    }

    public async Task<Employee?> GetEmployeeByEmailAsync(string email)
    {
        return await DbSet
            .Include(e => e.Role)
            .FirstOrDefaultAsync(e => e.Email == email);
    }
}
