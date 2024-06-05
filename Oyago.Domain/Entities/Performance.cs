using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.Entities
{
    public class Performance
    {
        [Key]
        public long Id { get; set; }

        public decimal ServiceRating { get; set; } = 0;
        public decimal LoadingPointRating { get; set; } = 0;
        public decimal PriceRating { get; set; } = 0;
        public decimal SuspiciousRating { get; set; } = 0;
        public decimal VehicleIdRating { get; set; } = 0;
        public decimal DriverIdRating { get; set; } = 0;
        public string? RouteType { get; set; }
        public int NoOfRatings {  get; set; } = 0;
        public string Username {  get; set; }
        public DateTime DateCreated { get; set;}
        public DateTime DateUpdated { get; set; }
    }
}
