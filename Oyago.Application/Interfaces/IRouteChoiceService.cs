using Oyago.Domain.DTOs;
using Oyago.Domain.Models;

namespace Oyago.Application.Interfaces
{
    public interface IRouteChoiceService
    {
        Task<ServerResponse<bool>> AddRouteChoice(AddRouteChoiceDto request);
        Task<ServerResponse<UserInfoDto>> ValidateOrc(string orc);
    }
}