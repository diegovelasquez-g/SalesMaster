using Microsoft.Extensions.Configuration;
using SalesMaster.Application.Domain.Entities;
using System.Security.Claims;

namespace SalesMaster.Application.Common.Interfaces;

public interface IAuthService
{
    string GenerateToken(Employee employee);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetTokenPrincipal(string token);
}
