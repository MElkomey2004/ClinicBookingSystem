using ClinicBookingSystem.Models;

namespace ClinicBookingSystem.Services.Interfaces
{
	public interface IClinicService
	{
		Task<IEnumerable<Clinic>> GetAllAsync();
		Task<Clinic?> GetByIdAsync(int id);
		Task AddAsync(Clinic clinic);
		Task UpdateAsync(Clinic clinic);
		Task DeleteAsync(int id);
	}
}
