using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.DTOs
{
    public class AddPerformanceDto
    {
        public int ServiceRating { get; set; } = 0;
        public int LoadingPointRating { get; set; } = 0;
        public int PriceRating { get; set; } = 0;
        public int SuspiciousRating { get; set; } = 0;
        public int VehicleIdRating { get; set; } = 0;
        public int DriverIdRating { get; set; } = 0;
        public string? RouteType { get; set; }
        public string Username { get; set; }
    }
}
