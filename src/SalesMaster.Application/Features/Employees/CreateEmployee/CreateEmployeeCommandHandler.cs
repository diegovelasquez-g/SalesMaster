using AutoMapper;
using MediatR;
using SalesMaster.Application.Common.Helpers;
using SalesMaster.Application.Domain.Entities;
using SalesMaster.Application.Domain.Interfaces;

namespace SalesMaster.Application.Features.Employees.CreateEmployee;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        PasswordHasher passwordHasher = new();
        var employee = _mapper.Map<Employee>(request);
        employee.Password = passwordHasher.Hash(request.Password);
        employee.CreatedBy = "SysAdmin";
        employee.CreatedDate = DateTime.UtcNow;
        await _unitOfWork.Employees.AddAsync(employee);
        return await _unitOfWork.SaveChanges() > 0;
    }
}
