using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.Entities
{
    public class RouteChoice
    {
        [Key]
        public long Id { get; set; }

        public string DayTime { get; set; }

        public string? VehicleHandOverName { get; set;}
        public string? VehicleHandOverPhone { get; set; }
        public string? Route { get; set; }

        public string? ORC { get; set; }
        public string? UserId { get; set; }
        public string? RouteCode { get; set; }
        public DateTime DateCreated { get; set;}

    }
}
