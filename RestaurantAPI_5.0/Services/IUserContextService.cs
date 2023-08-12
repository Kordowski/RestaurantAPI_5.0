using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace RestaurantAPI_5._0.Services
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        int? GetUserId {  get; }
    }
}
