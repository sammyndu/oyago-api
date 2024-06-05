using Oyago.Domain.DTOs;
using Oyago.Domain.Entities;
using Oyago.Domain.Models;

namespace Oyago.Application.Interfaces
{
    public interface IMatchingRouteService
    {
        Task<ServerResponse<bool>> AddMatchingRoute(AddMatchingRouteDto request);
        Task<ServerResponse<MatchingRoute>> GetMatchingRoute(int id);
        Task<ServerResponse<List<MatchingRoute>>> GetMatchingRoutes(string? username);
    }
}