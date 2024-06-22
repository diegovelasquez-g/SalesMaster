using MediatR;
using SalesMaster.Application.Common.Dtos.Responses;

namespace SalesMaster.Application.Features.Employees.GetEmployeeInfo;

public class GetEmployeeInfoQuery : IRequest<EmployeeInfoResponse>
{
    public Guid EmployeeId { get; set; }
}
