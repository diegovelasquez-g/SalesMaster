namespace SalesMaster.Application.Domain.Entities;

public class Employee : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public Guid RoleId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? ProfilePicture { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }
    public Role? Role { get; set; }
}