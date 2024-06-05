using Mapster;
using Microsoft.EntityFrameworkCore;
using Oyago.Application.Interfaces;
using Oyago.Data;
using Oyago.Domain.DTOs;
using Oyago.Domain.Entities;
using Oyago.Domain.Enums;
using Oyago.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Application.Implementations
{
    public class PerformanceService : BaseService, IPerformanceService
    {
        private readonly AppDbContext _db;
        public PerformanceService(AppDbContext db)
        {

            _db = db;

        }

        public async Task<ServerResponse<Performance>> GetPerformanceRating(string username, string routeType)
        {
            var result = new ServerResponse<Performance>();

            var user = await _db.Users.FindAsync(username);
            if (user == null)
            {
                return SetErrorResponse<Performance>("404", "User not found");
            }

            var queryResult = await _db.Performance.FirstOrDefaultAsync(x => x.Username == username && x.RouteType == routeType);

            if (queryResult == null)
            {
                var performance = new Performance
                {
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    DriverIdRating = 0,
                    LoadingPointRating = 0,
                    PriceRating = 0,
                    RouteType = routeType,
                    ServiceRating = 0,
                    SuspiciousRating = 0,
                    Username = username,
                    VehicleIdRating = 0,
                };

                _db.Performance.Add(performance);
                await _db.SaveChangesAsync();

                result.IsSuccessful = true;
                result.Data = performance;
                return result;
            }

            result.IsSuccessful = true;
            result.Data = queryResult;
            return result;

        }

        public async Task<ServerResponse<bool>> SetPerformanceRating(AddPerformanceDto request)
        {
            var result = new ServerResponse<bool>();
            var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == request.Username);
            if (user == null)
            {
                return SetErrorResponse<bool>("404", "User not found");
            }

            var performance = await _db.Performance.Where(x => x.Username == request.Username && x.RouteType == request.RouteType).FirstOrDefaultAsync();

            if (performance == null)
            {
                var dbPerformance = new Performance
                {
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    DriverIdRating = request.DriverIdRating,
                    LoadingPointRating = request.LoadingPointRating,
                    PriceRating = request.PriceRating,
                    RouteType = request.RouteType,
                    ServiceRating = request.ServiceRating,
                    SuspiciousRating = request.SuspiciousRating,
                    Username = request.Username,
                    VehicleIdRating = request.VehicleIdRating,
                };

                _db.Performance.Add(dbPerformance);

            }
            else
            {
                performance.DateUpdated = DateTime.Now;
                performance.VehicleIdRating = CalculateRating(performance.VehicleIdRating, request.VehicleIdRating, performance.NoOfRatings + 1);
                performance.PriceRating = CalculateRating(performance.PriceRating, request.PriceRating, performance.NoOfRatings + 1);
                performance.LoadingPointRating = CalculateRating(performance.LoadingPointRating, request.LoadingPointRating, performance.NoOfRatings + 1);
                performance.ServiceRating = CalculateRating(performance.ServiceRating, request.ServiceRating, performance.NoOfRatings + 1);
                performance.SuspiciousRating = CalculateRating(performance.SuspiciousRating, request.SuspiciousRating, performance.NoOfRatings + 1);
                performance.DriverIdRating = CalculateRating(performance.DriverIdRating, request.DriverIdRating, performance.NoOfRatings + 1);
                performance.NoOfRatings = performance.NoOfRatings + 1;

                _db.Performance.Update(performance);
            }

            if (await _db.SaveChangesAsync() != 1)
            {
                return SetErrorResponse<bool>("500", "Error occurred while saving performance");
            }

            result.IsSuccessful = true;
            result.Data = true;
            return result;


        }


        private decimal CalculateRating(decimal previousRating, decimal rating, int noOfRatings)
        {
            if (rating > 0)
            {
                return (previousRating + rating) / noOfRatings;
            }
            return previousRating;
        }
    }
}
