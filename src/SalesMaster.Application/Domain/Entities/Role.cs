namespace SalesMaster.Application.Domain.Entities;

public class Role : BaseEntity
{
    public Guid RoleId { get; set; }
    public string RoleName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ICollection<Employee>? Employees { get; set; }
}
