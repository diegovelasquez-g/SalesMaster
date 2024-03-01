using MediatR;
using Microsoft.Extensions.Configuration;
using SalesMaster.Application.Common.Dtos.Responses;
using SalesMaster.Application.Common.Helpers;
using SalesMaster.Application.Domain.Interfaces;

namespace SalesMaster.Application.Features.Employees.EmployeeAuth;

public class EmployeeAuthQueryHandler : IRequestHandler<EmployeeAuthQuery, LoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public EmployeeAuthQueryHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async Task<LoginResponse> Handle(EmployeeAuthQuery request, CancellationToken cancellationToken)
    {
        PasswordHasher passwordHasher = new();
        TokenGenerator tokenGenerator = new();

        var existingEmployee = await _unitOfWork.Employees.GetEmployeeByEmailAsync(request.Email);

        if (existingEmployee is null)
            throw new Exception("Employee not found");

        if (!passwordHasher.Verify(existingEmployee.Password, request.Password))
            throw new Exception("Invalid password");

        //Save refresh token to database and expiry date

        return new LoginResponse
        {
            Token = tokenGenerator.GenerateToken(existingEmployee, _configuration),
            RefreshToken = tokenGenerator.GenerateRefreshToken()
        };
    }
}
