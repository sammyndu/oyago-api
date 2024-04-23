

using Microsoft.AspNetCore.Identity;

namespace Oyago.Domain.Entities
{
    public partial class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser():base()
        {
            //UserRefreshTokens = new HashSet<UserRefreshToken>();
            //UserMerchantCategories = new HashSet<UserMerchantCategory>();
            IsActive= false;
            IsDeleted= false;
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? CanChangePassword { get; set; }
        public DateTime DateCreated { get; set; }  
        public DateTime? DOB { get; set; }  
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int LoginCount { get; set; }
        public bool? AcountLocked { get; set; }
        public string? LoadingPointType { get; set; }
        public string? LoadingPointLocation { get; set; }
 
     
	  
	    public string? HomeAddress { get; set; } 
	    public string? ResidentialAddress { get; set; } 
	    public string? UserType { get; set; } 
	    public string? DefaultRole { get; set; } 

        public string? UserImage { get; set;}
        public string? LoadingManagerId { get; set; }

	 


	  
    }
}
