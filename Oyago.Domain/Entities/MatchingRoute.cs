using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.Entities
{
    public class MatchingRoute
    {
        [Key]
        public long Id { get; set; }
        public DateTime FirstStartTime { get; set; }
        public DateTime SecondStartTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int VehicleCapacity { get; set; }
        public string? PlateNumber { get; set;}
        public string? FirstPickPoint { get; set;}
        public string? SecondPickPoint { get;set;}
        public string? Destination { get; set; }
        public string? Route { get; set;}
        public decimal? FirstPrice { get; set;} 
        public decimal? SecondPrice { get; set;}
        public int CurrentTotalSeat {  get; set; }

        public bool IsPaid { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Username { get;set; }
        public string? RouteCode { get; set; }

    }
}
