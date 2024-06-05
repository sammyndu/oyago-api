using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.DTOs
{
    public class TapInPassengerDto
    {
        public string? UsernameOrPhonenumber { get; set; }
        public bool CompleteSeats { get; set; } = false;
    }
}
