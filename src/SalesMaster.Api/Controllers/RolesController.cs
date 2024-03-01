using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesMaster.Application.Features.Roles.CreateRole;

namespace SalesMaster.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
