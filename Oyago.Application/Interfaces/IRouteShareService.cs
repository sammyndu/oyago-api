using Oyago.Domain.DTOs;
using Oyago.Domain.Entities;
using Oyago.Domain.Models;

namespace Oyago.Application.Interfaces
{
    public interface IRouteShareService
    {
        Task<ServerResponse<bool>> AddRouteShare(AddRouteShareDto request);
        Task<ServerResponse<RouteShare>> GetRouteShare(int id);
        Task<ServerResponse<List<RouteShare>>> GetRouteShares(string? username);
        Task<ServerResponse<bool>> RemovePassenger(string? userId, int routeShareId);
        Task<ServerResponse<bool>> TapInPassenger(TapInPassengerDto request, int routeShareId);
    }
}