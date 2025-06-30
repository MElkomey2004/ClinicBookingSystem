using ClinicBookingSystem.Models;

namespace ClinicBookingSystem.Repositories.Interfaces
{
	public interface IClinicRepository
	{
		Task<IEnumerable<Clinic>> GetAllAsync();
		Task<Clinic?> GetByIdAsync(int id);
		Task AddAsync(Clinic clinic);
		Task UpdateAsync(Clinic clinic);
		Task DeleteAsync(int id);
	}
}
