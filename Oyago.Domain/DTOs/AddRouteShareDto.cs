using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.DTOs
{
    public class AddRouteShareDto
    {
        public string? DriverUserId { get; set; }
        public string? LoadingManagerId { get; set; }
        public string? Route { get; set; }
        public string? VehicleType { get; set; }
        public int SeatCapacity { get; set; }
        public string? PlateNumber { get; set; }
        public decimal? Price { get; set; }
    }
}
