using Oyago.Domain.DTOs;
using Oyago.Domain.Entities;
using Oyago.Domain.Models;

namespace Oyago.Application.Interfaces
{
    public interface IPerformanceService
    {
        Task<ServerResponse<Performance>> GetPerformanceRating(string username, string routeType);
        Task<ServerResponse<bool>> SetPerformanceRating(AddPerformanceDto request);
    }
}