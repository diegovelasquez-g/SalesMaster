namespace SalesMaster.Application.Common.Dtos.Responses;

public class EmployeeInfoResponse
{
    public string EmployeeId { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!; 
    public string Username { get; set; } = default!;
    public string? ProfilePicture { get; set; }
}
