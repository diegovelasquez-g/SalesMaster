﻿using MediatR;
using SalesMaster.Application.Common.Dtos.Responses;

namespace SalesMaster.Application.Features.Employees.EmployeeAuth;

public class EmployeeAuthQuery : IRequest<LoginResponse>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
