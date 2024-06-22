using MediatR;
using SalesMaster.Application.Common.Dtos.Responses;

namespace SalesMaster.Application.Features.Employees.RefreshToken;

public class RefreshTokenCommand : IRequest<LoginResponse>
{
    public string Token { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
}
