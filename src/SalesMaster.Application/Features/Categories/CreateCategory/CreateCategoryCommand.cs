using MediatR;

namespace SalesMaster.Application.Features.Categories.CreateCategory;

public class CreateCategoryCommand : IRequest<bool>
{
    public string CategoryName { get; set; } = default!;
    public string Description { get; set; } = default!;
}
