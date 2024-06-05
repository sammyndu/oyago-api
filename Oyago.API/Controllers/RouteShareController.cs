using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oyago.Application.Interfaces;
using Oyago.Domain.DTOs;
using Oyago.Domain.Entities;
using Oyago.Domain.Models;
using System.Net;

namespace Oyago.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteShareController : ControllerBase
    {
        private readonly IRouteShareService _routeShareService;
        public RouteShareController(
            IRouteShareService routeShareService)
        {
            _routeShareService = routeShareService;
        }

        [HttpGet("routeshare/{id}")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<RouteShare>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> GetRouteShare(int id)
        {
            var result = await _routeShareService.GetRouteShare(id);
            if(result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }

        [HttpGet("routeshares/{username}")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<List<RouteShare>>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> GetRouteShares(string username)
        {
            var result = await _routeShareService.GetRouteShares(username);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }

        [HttpPost("addrouteshare")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> AddRouteShare([FromBody] AddRouteShareDto request)
        {
            var result = await _routeShareService.AddRouteShare(request);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }

        [HttpPost("TapinPassenger/{routeShareId}")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> TapinPassenger([FromBody] TapInPassengerDto request, int routeShareId)
        {
            var result = await _routeShareService.TapInPassenger(request, routeShareId);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }

        [HttpPost("RemovePassenger/{routeShareId}")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> RemovePassenger(int routeShareId, [FromQuery] string username)
        {
            var result = await _routeShareService.RemovePassenger(username, routeShareId);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }
    }
}
