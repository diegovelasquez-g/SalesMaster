using MediatR;

namespace SalesMaster.Application.Features.Roles.CreateRole;

public class CreateRoleCommand : IRequest<bool>
{
    public string RoleName { get; set; } = default!;
    public string Description { get; set; } = default!;
}
