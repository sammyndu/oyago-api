using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oyago.Application.Interfaces;
using Oyago.Data;
using Oyago.Domain.DTOs;
using Oyago.Domain.Entities;
using Oyago.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Application.Implementations
{
    public class RouteChoiceService : IRouteChoiceService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public RouteChoiceService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ServerResponse<UserInfoDto>> ValidateOrc(string orc)
        {
            var result = new ServerResponse<UserInfoDto>();

            var query = _db.AssignRoute.Where(x => x.RegisterationId == orc);
            var queryResult = await query.FirstOrDefaultAsync();

            if (queryResult == null)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "500",
                    ResponseDescription = "ORC does not exist",
                    ResponseMessage = "ORC does not exist"
                };
                return result;
            }

            var userQuery = _db.Users.Where(x => x.Id == queryResult.UserId).FirstOrDefaultAsync();

            if (userQuery == null)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "500",
                    ResponseDescription = "User with the ORC not found",
                    ResponseMessage = "User with the ORC not found"
                };
            }

            var dto = userQuery.Adapt<UserInfoDto>();

            result.Data = dto;
            return result;
        }

        public async Task<ServerResponse<bool>> AddRouteChoice(AddRouteChoiceDto request)
        {
            var result = new ServerResponse<bool>();

            var dbRequest = request.Adapt<RouteChoice>();

            var query = await _db.RouteChoice.AddAsync(dbRequest);

            if (await _db.SaveChangesAsync() != 1)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "500",
                    ResponseDescription = "Route Choice could not be saved",
                    ResponseMessage = "Route Choice could not be saved"
                };
                return result;
            }

            result.Data = true;
            return result;


        }
    }
}
