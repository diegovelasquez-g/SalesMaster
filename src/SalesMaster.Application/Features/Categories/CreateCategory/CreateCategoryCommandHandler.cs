using AutoMapper;
using MediatR;
using SalesMaster.Application.Domain.Entities;
using SalesMaster.Application.Domain.Interfaces;

namespace SalesMaster.Application.Features.Categories.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        category.CreatedBy = "SysAdmin"; //Change to logged in user
        category.CreatedDate = DateTime.UtcNow;
        await _unitOfWork.Categories.AddAsync(category);
        return await _unitOfWork.SaveChanges() > 0;
    }
}
