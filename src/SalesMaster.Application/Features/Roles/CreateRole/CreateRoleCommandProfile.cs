using AutoMapper;
using SalesMaster.Application.Domain.Entities;

namespace SalesMaster.Application.Features.Roles.CreateRole;

public class CreateRoleCommandProfile : Profile
{
    public CreateRoleCommandProfile()
    {
        CreateMap<CreateRoleCommand, Role>()
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => Guid.NewGuid()));
    }
}
