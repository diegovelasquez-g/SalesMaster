using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesMaster.Application.Features.Employees.CreateEmployee;
using SalesMaster.Application.Features.Employees.EmployeeAuth;

namespace SalesMaster.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromServices] IMediator mediator, CreateEmployeeCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("auth")]
    public async Task<IActionResult> EmployeeAuth([FromServices] IMediator mediator, EmployeeAuthQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
