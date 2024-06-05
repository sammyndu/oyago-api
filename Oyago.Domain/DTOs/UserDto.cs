using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.DTOs
{
    public class UserDto
    {
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string? LoadingPointType { get; set; }
        public string? LoadingPointLocation { get; set; }
        public string DefaultRole { get; set; }
    }
}
