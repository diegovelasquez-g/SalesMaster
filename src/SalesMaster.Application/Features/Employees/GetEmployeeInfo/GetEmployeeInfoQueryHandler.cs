using MediatR;
using SalesMaster.Application.Common.Dtos.Responses;
using SalesMaster.Application.Common.Exceptions;
using SalesMaster.Application.Domain.Entities;
using SalesMaster.Application.Domain.Interfaces;

namespace SalesMaster.Application.Features.Employees.GetEmployeeInfo;

public class GetEmployeeInfoQueryHandler : IRequestHandler<GetEmployeeInfoQuery, EmployeeInfoResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEmployeeInfoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EmployeeInfoResponse> Handle(GetEmployeeInfoQuery request, CancellationToken cancellationToken)
    {
        var employeeInfo = new EmployeeInfoResponse();

        var employee = await _unitOfWork.Employees.GetByIdAsync(request.EmployeeId);
        if (employee is null)
            throw new NotFoundException("Employee not found");

        employeeInfo.Email = employee.Email;
        employeeInfo.EmployeeId = employee.EmployeeId.ToString();
        employeeInfo.FirstName = employee.FirstName;
        employeeInfo.LastName = employee.LastName;
        employeeInfo.Username = employee.Username;
        employeeInfo.ProfilePicture = employee.ProfilePicture;

        return employeeInfo;
    }
}
