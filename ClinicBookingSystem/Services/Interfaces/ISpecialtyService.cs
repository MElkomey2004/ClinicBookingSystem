using ClinicBookingSystem.Models;

namespace ClinicBookingSystem.Services.Interfaces
{
	public interface ISpecialtyService
	{
		Task<IEnumerable<Specialty>> GetAllAsync();
		Task<Specialty?> GetByIdAsync(int id);
		Task AddAsync(Specialty specialty);
		Task UpdateAsync(Specialty specialty);
		Task DeleteAsync(int id);
	}
}
