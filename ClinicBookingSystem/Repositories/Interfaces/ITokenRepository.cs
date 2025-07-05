using Microsoft.AspNetCore.Identity;

namespace ClinicBookingSystem.Repositories.Interfaces
{
	public interface ITokenRepository
	{
		string CreateJWTToken(IdentityUser user, List<string> roles);
	}
}
