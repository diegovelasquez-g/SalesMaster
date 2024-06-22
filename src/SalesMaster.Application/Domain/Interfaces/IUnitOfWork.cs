namespace SalesMaster.Application.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository Employees { get; }
    IRoleRepository Roles { get; }
    ICategoryRepository Categories { get; }
    Task<int> SaveChanges();
}
