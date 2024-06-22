using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesMaster.Application.Features.Employees.CreateEmployee;
using SalesMaster.Application.Features.Employees.EmployeeAuth;
using SalesMaster.Application.Features.Employees.GetEmployeeInfo;
using SalesMaster.Application.Features.Employees.RefreshToken;

namespace SalesMaster.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("auth")]
    public async Task<IActionResult> EmployeeAuth([FromBody] EmployeeAuthCommand query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("employeeInfo")]
    public async Task<IActionResult> EmployeeInfo(Guid employeeId)
    {
        var query = new GetEmployeeInfoQuery { EmployeeId = employeeId};
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
