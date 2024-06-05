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
    public class PerformanceController : ControllerBase
    {
        private readonly IPerformanceService _performanceService;
        public PerformanceController(
            IPerformanceService performanceService
            )
        {
            _performanceService = performanceService;
        }

        [HttpGet("getperformancerating/{username}")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<Performance>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> GetPerformanceRating([FromQuery] string routeType, string username)
        {
            var result =  await _performanceService.GetPerformanceRating(routeType, username);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }

        [HttpPost("setperformancerating")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServerResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> SetPerformanceRating([FromBody] AddPerformanceDto request)
        {
            var result = await _performanceService.SetPerformanceRating(request);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorResponse);
        }
    }
}
