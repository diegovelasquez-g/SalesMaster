using AutoMapper;
using MediatR;
using SalesMaster.Application.Domain.Entities;
using SalesMaster.Application.Domain.Interfaces;

namespace SalesMaster.Application.Features.Roles.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = _mapper.Map<Role>(request);
        role.CreatedBy = "SysAdmin";
        role.CreatedDate = DateTime.UtcNow;
        await _unitOfWork.Roles.AddAsync(role);
        return await _unitOfWork.SaveChanges() > 0;
    }
}
