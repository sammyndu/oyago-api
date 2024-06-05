using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.Entities
{
    public class AssignRoute
    {
        [Key]
        public long Id { get; set; }
        public string Document { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string PlateNumber { get; set; }

        public string RegisterationId { get; set; }

        public string UserId { get; set;}

        public DateTime DateCreated { get; set;}
    }
}
