namespace SalesMaster.Application.Domain.Entities;

public class Provider : BaseEntity
{
    public Guid ProviderId { get; set; }
    public string ProviderName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public ICollection<Product>? Products { get; set; }
    //public string Address { get; set; } = default!;
}
