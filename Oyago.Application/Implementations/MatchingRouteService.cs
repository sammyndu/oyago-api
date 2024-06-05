using Mapster;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
    public class MatchingRouteService : BaseService, IMatchingRouteService
    {
        private readonly AppDbContext _db;
        public MatchingRouteService(
            AppDbContext db)
        {
            _db = db;
        }

        public async Task<ServerResponse<bool>> AddMatchingRoute(AddMatchingRouteDto request)
        {
            var result = new ServerResponse<bool>();

            var dbRequest = request.Adapt<MatchingRoute>();

            dbRequest.DateCreated = DateTime.Now;
            dbRequest.DateUpdated = DateTime.Now;
            dbRequest.IsPaid = false;
            //dbRequest.Passengers = JsonConvert.SerializeObject(new List<string>());

            await _db.MatchingRoute.AddAsync(dbRequest);

            if (await _db.SaveChangesAsync() != 1)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "500",
                    ResponseDescription = "Error occurred while saving Matching Route",
                    ResponseMessage = "Error occurred while saving Matching Route"
                };
                return result;
            }

            result.IsSuccessful = true;
            result.Data = true;
            return result;
        }



        public async Task<ServerResponse<MatchingRoute>> GetMatchingRoute(int id)
        {
            var result = new ServerResponse<MatchingRoute>();

            var queryResult = await _db.MatchingRoute.FirstOrDefaultAsync(x => x.Id == id);

            if (queryResult == null)
            {
                return SetErrorResponse<MatchingRoute>("404", "Record not found");
            }

            result.IsSuccessful = true;
            result.Data = queryResult;
            return result;
        }

        public async Task<ServerResponse<List<MatchingRoute>>> GetMatchingRoutes(string? username)
        {
            var result = new ServerResponse<List<MatchingRoute>>();

            if (username == null)
            {

            }

            var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == username || x.PhoneNumber == username);

            if (user == null)
            {
                return SetErrorResponse<List<MatchingRoute>>("404", "User not found");
            }

            var queryResult = await _db.MatchingRoute.Where(x => x.Username == username).ToListAsync();


            result.IsSuccessful = true;
            result.Data = queryResult;
            return result;
        }
    }
}
