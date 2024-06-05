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
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ServerResponse<bool>> PassengerSignupAsync(PassengerSignUpDto request)
        {
            var result = new ServerResponse<bool>();
            var userExists = _db.Users.Any(x => x.UserName == request.UserName || x.PhoneNumber == request.PhoneNumber);
            if (userExists)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "400",
                    ResponseMessage = "User already exists"
                };
                return result;
            }
            var passenger = request.Adapt<ApplicationUser>();
            passenger.DefaultRole = Role.Passenger.ToString();
            await _db.Users.AddAsync(passenger);

            var save = await _db.SaveChangesAsync();
            if (save < 1)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "500",
                    ResponseMessage = "Passenger Sign Up Failed"
                };
                return result;
            }

            result.IsSuccessful = true;
            return result;



        }

        public async Task<ServerResponse<bool>> DriverSignupAsync(DriverSignUpDto request)
        {
            var result = new ServerResponse<bool>();
            var userExists = _db.Users.Any(x => x.UserName == request.UserName || x.PhoneNumber == request.PhoneNumber);
            if (userExists)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "400",
                    ResponseMessage = "User already exists"
                };
                return result;
            }
            var driver = request.Adapt<ApplicationUser>();
            await _db.Users.AddAsync(driver);

            var save = await _db.SaveChangesAsync();
            if (save < 1)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "500",
                    ResponseMessage = "Driver Sign Up Failed"
                };
                return result;
            }

            result.IsSuccessful = true;
            return result;



        }

        public async Task<ServerResponse<bool>> ManagerSignupAsync(ManagerSignUpDto request)
        {
            var result = new ServerResponse<bool>();
            var userExists = _db.Users.Any(x => x.UserName == request.UserName || x.PhoneNumber == request.PhoneNumber);
            if (userExists)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "400",
                    ResponseMessage = "User already exists"
                };
                return result;
            }
            var manager = request.Adapt<ApplicationUser>();
            manager.DefaultRole = Role.LoadingPointManager.ToString();
            await _db.Users.AddAsync(manager);

            var save = await _db.SaveChangesAsync();
            if (save < 1)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "500",
                    ResponseMessage = "Driver Sign Up Failed"
                };
                return result;
            }

            result.IsSuccessful = true;
            return result;



        }

        public async Task<ServerResponse<UserDto>> LoginAsync(LoginDto request)
        {
            var result = new ServerResponse<UserDto>();

            var user = await _db.Users.ProjectToType<UserDto>().FirstOrDefaultAsync(x => x.UserName == request.UserName);
            if (user == null)
            {
                result.ErrorResponse = new ErrorResponse
                {
                    ResponseCode = "404",
                    ResponseMessage = "User not found"
                };
                return result;
            }

            result.IsSuccessful = true;
            result.Data = user;
            return result;
        }
    }
}
