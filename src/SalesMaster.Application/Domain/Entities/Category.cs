namespace SalesMaster.Application.Domain.Entities;

public class Category : BaseEntity
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ICollection<Product>? Products { get; set; }
}
