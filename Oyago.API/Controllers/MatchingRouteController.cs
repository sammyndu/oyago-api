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
    public class MatchingRouteController : ControllerBase
    {
        private readonly IMatchingRouteService _matchingRouteService;
        public MatchingRouteController(
            IMatchingRouteService matchingRouteService
            )
        {
            _matchingRouteService = matchingRouteService;
        }

        [HttpGet("getmatchingroutes/{username}")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<List<MatchingRoute>>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> GetMatchingRoutes(string username)
        {
            var result = await _matchingRouteService.GetMatchingRoutes(username);
            if(result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }

        [HttpGet("getmatchingroute/{id}")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<MatchingRoute>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> GetMatchingRoute(int id)
        {
            var result = await _matchingRouteService.GetMatchingRoute(id);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }

        [HttpPost("addmatchingroute")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> AddMatchingRoute([FromBody] AddMatchingRouteDto request)
        {
            var result = await _matchingRouteService.AddMatchingRoute(request);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }
    }
}
