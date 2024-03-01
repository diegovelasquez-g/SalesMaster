namespace SalesMaster.Application.Domain.Entities;

public class Product : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ProviderId { get; set; }
    public Guid StockId { get; set; }
    public string ProductName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? ImageUrl { get; set; }
    public decimal UnitPrice { get; set; }
    public Category? Category { get; set; }
    public Provider? Provider { get; set; }
    public Stock? Stock { get; set; }
}
