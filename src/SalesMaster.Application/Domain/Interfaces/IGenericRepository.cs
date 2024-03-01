namespace SalesMaster.Application.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(T entity);
    IQueryable<T> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
}
