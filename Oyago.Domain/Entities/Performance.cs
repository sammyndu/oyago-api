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

        public int ServiceRating { get; set; } = 0;
        public int LoadingPointRating { get; set; } = 0;
        public int PriceRating { get; set; } = 0;
        public int SuspiciousRating { get; set; } = 0;
        public int VehicleIdRating { get; set; } = 0;
        public int DriverIdRating { get; set; } = 0;
        public string? RouteType { get; set; }
        public string UserId {  get; set; }
        public DateTime DateCreated { get; set;}
    }
}
