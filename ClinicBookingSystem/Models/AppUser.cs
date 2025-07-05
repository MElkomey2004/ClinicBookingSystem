using Microsoft.AspNetCore.Identity;

namespace ClinicBookingSystem.Models
{
	public class AppUser : IdentityUser
	{
		public string FullName { get;set; } 
	}
}
