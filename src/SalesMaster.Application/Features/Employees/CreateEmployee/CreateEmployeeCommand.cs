using MediatR;

namespace SalesMaster.Application.Features.Employees.CreateEmployee;

public class CreateEmployeeCommand : IRequest<bool>
{
    public Guid RoleId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}
