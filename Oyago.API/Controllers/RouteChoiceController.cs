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
    public class RouteChoiceController : ControllerBase
    {
        private readonly IRouteChoiceService _routeChoiceService;
        public RouteChoiceController(
            IRouteChoiceService routeChoiceService
            )
        {
            _routeChoiceService = routeChoiceService;
        }

        [HttpGet("validateorc/{orc}")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<UserInfoDto>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> ValidateORC(string orc)
        {
            var result = await _routeChoiceService.ValidateOrc(orc);
            if(result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }

        [HttpPost("addroutechoice")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> AddRouteChoice([FromBody] AddRouteChoiceDto request)
        {
            var result = await _routeChoiceService.AddRouteChoice(request);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }
    }
}
