namespace SalesMaster.Application.Common.Dtos.Responses;

public class LoginResponse
{
    public string Token { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
}
