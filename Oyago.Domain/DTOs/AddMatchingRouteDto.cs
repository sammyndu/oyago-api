using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.DTOs
{
    public class AddMatchingRouteDto
    {
        public DateTime FirstStartTime { get; set; }
        public DateTime SecondStartTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int VehicleCapacity { get; set; }
        public string? PlateNumber { get; set; }
        public string? FirstPickPoint { get; set; }
        public string? SecondPickPoint { get; set; }
        public string? Destination { get; set; }
        public string? Route { get; set; }
        public decimal? FirstPrice { get; set; }
        public decimal? SecondPrice { get; set; }
        public int CurrentTotalSeat { get; set; }
        public bool isPaid { get; set; }
        public string Username { get; set; }
        public string? RouteCode { get; set; }
    }
}
