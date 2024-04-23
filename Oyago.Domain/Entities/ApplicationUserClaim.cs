using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.Entities
{
    public class ApplicationUserClaim :  IdentityUserClaim<string>
    {
        //public string AppId { get; set; }
    }
}
