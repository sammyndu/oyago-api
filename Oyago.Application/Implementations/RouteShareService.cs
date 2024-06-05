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
    public class RouteShareService : BaseService, IRouteShareService
    {
        private readonly AppDbContext _db;
        public RouteShareService()
        {

        }

        public async Task<ServerResponse<bool>> AddRouteShare(AddRouteShareDto request)
        {
            var result = new ServerResponse<bool>();

            var dbRequest = request.Adapt<RouteShare>();

            dbRequest.DateCreated = DateTime.Now;
            dbRequest.DateUpdated = DateTime.Now;
            dbRequest.IsPaid = false;
            dbRequest.Passengers = JsonConvert.SerializeObject(new List<string>());

            await _db.RouteShare.AddAsync(dbRequest);

            if (await _db.SaveChangesAsync() != 1)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "500",
                    ResponseDescription = "Error occurred while saving Route Share",
                    ResponseMessage = "Error occurred while saving Route Share"
                };
                return result;
            }

            result.IsSuccessful = true;
            result.Data = true;
            return result;
        }

        public async Task<ServerResponse<bool>> TapInPassenger(TapInPassengerDto request, int routeShareId)
        {
            var result = new ServerResponse<bool>();

            var routeShareRecord = await _db.RouteShare.FirstOrDefaultAsync(x => x.Id == routeShareId);

            if (routeShareRecord == null)
            {
                return SetErrorResponse<bool>("500", "Route Share Record not found");
            }

            if (request.CompleteSeats)
            {
                return await TapInPassengerSaveChangesAsync(routeShareRecord, result, request.CompleteSeats);
            }

            if (string.IsNullOrWhiteSpace(request.UsernameOrPhonenumber))
            {
                return await TapInPassengerSaveChangesAsync(routeShareRecord, result, request.CompleteSeats);
            }

            var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == request.UsernameOrPhonenumber || x.PhoneNumber == request.UsernameOrPhonenumber);

            if (user == null)
            {
                return SetErrorResponse<bool>("500", "User not found");
            }

            var passengers = JsonConvert.DeserializeObject<List<string>>(routeShareRecord.Passengers);
            passengers?.Add(user.Id);

            routeShareRecord.Passengers = JsonConvert.SerializeObject(passengers);
            return await TapInPassengerSaveChangesAsync(routeShareRecord, result, request.CompleteSeats);
        }

        private async Task<ServerResponse<bool>> TapInPassengerSaveChangesAsync(RouteShare routeShareRecord, ServerResponse<bool> result, bool completeSeats)
        {
            if (completeSeats)
            {
                routeShareRecord.IsFull = true;
            }
            else
            {
                routeShareRecord.CurrentTotalSeats += 1;
                if (routeShareRecord.CurrentTotalSeats == routeShareRecord.SeatCapacity)
                {
                    routeShareRecord.IsFull = true;
                }
                routeShareRecord.DateUpdated = DateTime.Now;
            }

            _db.RouteShare.Update(routeShareRecord);
            if (await _db.SaveChangesAsync() != 1)
            {
                return SetErrorResponse<bool>("500", "Error occurred while adding Passenger");
            }

            result.IsSuccessful = true;
            result.Data = true;
            return result;
        }

        public async Task<ServerResponse<bool>> RemovePassenger(string? username, int routeShareId)
        {
            var result = new ServerResponse<bool>();

            var record = await _db.RouteShare.FirstOrDefaultAsync(x => x.Id == routeShareId);

            if (record == null)
            {
                return SetErrorResponse<bool>("500", "Record not found");
            }

            if (username != null)
            {
                var passengers = JsonConvert.DeserializeObject<List<string>>(record.Passengers);
                passengers.Remove(username);
                record.Passengers = JsonConvert.SerializeObject(passengers);
            }

            record.CurrentTotalSeats -= 1;
            record.DateUpdated = DateTime.Now;

            await _db.RouteShare.AddAsync(record);

            if (await _db.SaveChangesAsync() != 1)
            {
                return SetErrorResponse<bool>("500", "Error occurred while removing Passenger");
            }

            result.IsSuccessful = true;
            result.Data = true;
            return result;

        }

        public async Task<ServerResponse<RouteShare>> GetRouteShare(int id)
        {
            var result = new ServerResponse<RouteShare>();

            var queryResult = await _db.RouteShare.FirstOrDefaultAsync(x => x.Id == id);

            if (queryResult == null)
            {
                return SetErrorResponse<RouteShare>("404", "Record not found");
            }

            result.IsSuccessful = true;
            result.Data = queryResult;
            return result;
        }

        public async Task<ServerResponse<List<RouteShare>>> GetRouteShares(string? username)
        {
            var result = new ServerResponse<List<RouteShare>>();

            if (username == null)
            {

            }

            var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == username || x.PhoneNumber == username);

            if (user == null)
            {
                return SetErrorResponse<List<RouteShare>>("404", "User not found");
            }

            var queryResult = await _db.RouteShare.Where(x => x.DriverUserId == user.Id).ToListAsync();


            result.IsSuccessful = true;
            result.Data = queryResult;
            return result;
        }



    }
}