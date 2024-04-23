using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.Entities
{
    public class RouteShare
    {
        [Key]
        public long Id { get; set; }
        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserId { get; set; }
        public string? Route { get; set;}
        public string? VehicleType { get; set;}
        public string? SeatCapacity { get; set;}
        public string? PlateNumber { get; set; }
        public decimal? Price { get; set; }
        public bool isPaid { get; set; }
        public int CurrentTotalSeats {  get; set; }
        public string RouteCode { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
