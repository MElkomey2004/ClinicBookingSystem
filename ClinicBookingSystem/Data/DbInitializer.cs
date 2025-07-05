using Microsoft.AspNetCore.Identity;

namespace ClinicBookingSystem.Data
{
	public static class DbInitializer
	{
		public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
		{
			string[] roleNames = { "Admin", "Patient", "Doctor" }; // Add your roles here

			foreach (var role in roleNames)
			{
				var roleExist = await roleManager.RoleExistsAsync(role);
				if (!roleExist)
				{
					await roleManager.CreateAsync(new IdentityRole(role));
				}
			}
		}
	}
}
