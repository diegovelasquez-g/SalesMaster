using Microsoft.EntityFrameworkCore;
using SalesMaster.Application.Domain.Interfaces;
using SalesMaster.Application.Infraestructure.Persistance;

namespace SalesMaster.Application.Domain.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly SalesMasterDbContext _context;
    protected DbSet<T> DbSet => _context.Set<T>();

    public GenericRepository(SalesMasterDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void UpdateAsync(T entity)
    {
        _context.Update(entity);
    }

    public void DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> GetAllAsync()
    {
        return _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
}