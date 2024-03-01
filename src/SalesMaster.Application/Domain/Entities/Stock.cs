namespace SalesMaster.Application.Domain.Entities;

public class Stock : BaseEntity
{
    public Guid StockId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public ICollection<Product>? Products { get; set; }
}
