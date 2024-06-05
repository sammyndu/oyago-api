using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.DTOs
{
    public class ManagerSignUpDto
    {
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string LoadingPointType { get; set; }
        public string LoadingPointLocation { get; set; }
    }
}
