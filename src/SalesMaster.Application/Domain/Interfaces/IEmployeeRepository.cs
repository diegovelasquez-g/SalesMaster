using SalesMaster.Application.Domain.Entities;

namespace SalesMaster.Application.Domain.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<Employee?> GetEmployeeByEmailAsync(string email);
}
