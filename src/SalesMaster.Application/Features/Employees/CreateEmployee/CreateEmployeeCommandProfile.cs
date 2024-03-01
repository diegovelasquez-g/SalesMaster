using AutoMapper;
using SalesMaster.Application.Domain.Entities;

namespace SalesMaster.Application.Features.Employees.CreateEmployee;

public class CreateEmployeeCommandProfile : Profile
{
    public CreateEmployeeCommandProfile()
    {
        CreateMap<CreateEmployeeCommand, Employee>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => Guid.NewGuid()));
    }
}
