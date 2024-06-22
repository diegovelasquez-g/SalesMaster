using MediatR;
using SalesMaster.Application.Common.Dtos.Responses;
using SalesMaster.Application.Common.Exceptions;
using SalesMaster.Application.Common.Interfaces;
using SalesMaster.Application.Domain.Interfaces;
using System.Security.Claims;

namespace SalesMaster.Application.Features.Employees.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, LoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public RefreshTokenCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<LoginResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginResponse loginResponse = new();

        var tokenPrincipal = _authService.GetTokenPrincipal(request.Token);
        if(tokenPrincipal?.Identity?.Name is null)
            throw new NotFoundException();

        Guid employeeId = Guid.Parse(tokenPrincipal.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        var employee = await _unitOfWork.Employees.GetByIdAsync(employeeId);
        if(employee == null) throw new NotFoundException();

        //Validate refresh token
        if (employee.RefreshToken != request.RefreshToken || employee.RefreshTokenExpiry < DateTime.UtcNow)
            return loginResponse;


        loginResponse.Token = _authService.GenerateToken(employee);
        loginResponse.RefreshToken = _authService.GenerateRefreshToken();
        DateTime expiryDate = DateTime.UtcNow.AddMinutes(10);

        throw new NotImplementedException();
    }
}
