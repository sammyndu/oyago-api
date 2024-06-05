using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oyago.Application.Interfaces;
using Oyago.Domain.DTOs;
using Oyago.Domain.Models;
using System.Net;

namespace Oyago.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<UserDto>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var result = await _userService.LoginAsync(request);
            if(result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }

        [HttpPost("passengerSignUp")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> PassengerSignUp([FromBody] PassengerSignUpDto request)
        {
            var result = await _userService.PassengerSignupAsync(request);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }

        [HttpPost("driverSignUp")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> DriverSignUp([FromBody] DriverSignUpDto request)
        {
            var result = await _userService.DriverSignupAsync(request);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }

        [HttpPost("managerSignUp")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> ManagerSignUp([FromBody] ManagerSignUpDto request)
        {
            var result = await _userService.ManagerSignupAsync(request);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }
    }
}
