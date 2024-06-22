using AutoMapper;
using SalesMaster.Application.Domain.Entities;

namespace SalesMaster.Application.Features.Categories.CreateCategory;

public class CreateCategoryCommandProfile : Profile
{
    public CreateCategoryCommandProfile()
    {
        CreateMap<CreateCategoryCommand, Category>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => Guid.NewGuid())); ;
    }
}
