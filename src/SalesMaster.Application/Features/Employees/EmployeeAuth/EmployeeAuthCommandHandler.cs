using MediatR;
using SalesMaster.Application.Common.Dtos.Responses;
using SalesMaster.Application.Common.Helpers;
using SalesMaster.Application.Common.Interfaces;
using SalesMaster.Application.Domain.Interfaces;

namespace SalesMaster.Application.Features.Employees.EmployeeAuth;

public class EmployeeAuthCommandHandler : IRequestHandler<EmployeeAuthCommand, LoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public EmployeeAuthCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<LoginResponse> Handle(EmployeeAuthCommand request, CancellationToken cancellationToken)
    {
        PasswordHasher passwordHasher = new();
        LoginResponse loginResponse = new();

        var existingEmployee = await _unitOfWork.Employees.GetEmployeeByEmailAsync(request.Email);

        if (existingEmployee is null)
            throw new Exception("Employee not found");

        if (!passwordHasher.Verify(existingEmployee.Password, request.Password))
            throw new Exception("Invalid password");

        loginResponse.EmployeeId = existingEmployee.EmployeeId.ToString();
        loginResponse.Token = _authService.GenerateToken(existingEmployee);
        loginResponse.RefreshToken = _authService.GenerateRefreshToken();
        DateTime expiryDate = DateTime.UtcNow.AddMinutes(10);

        existingEmployee.RefreshToken = loginResponse.RefreshToken;
        existingEmployee.RefreshTokenExpiry = expiryDate;
        _unitOfWork.Employees.UpdateAsync(existingEmployee);
        await _unitOfWork.SaveChanges();

        return loginResponse;
    }
}
