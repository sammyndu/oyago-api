using Oyago.Domain.DTOs;
using Oyago.Domain.Models;

namespace Oyago.Application.Interfaces
{
    public interface IUserService
    {
        Task<ServerResponse<bool>> DriverSignupAsync(DriverSignUpDto request);
        Task<ServerResponse<UserDto>> LoginAsync(LoginDto request);
        Task<ServerResponse<bool>> ManagerSignupAsync(ManagerSignUpDto request);
        Task<ServerResponse<bool>> PassengerSignupAsync(PassengerSignUpDto request);
    }
}