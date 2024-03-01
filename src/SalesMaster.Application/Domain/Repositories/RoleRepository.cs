using SalesMaster.Application.Domain.Entities;
using SalesMaster.Application.Domain.Interfaces;
using SalesMaster.Application.Infraestructure.Persistance;

namespace SalesMaster.Application.Domain.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(SalesMasterDbContext context) : base(context)
    {
    }
}
