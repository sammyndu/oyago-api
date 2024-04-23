using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.Entities
{
    public class ApplicationRole:IdentityRole<string>
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
