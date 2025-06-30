using ClinicBookingSystem.Models;

namespace ClinicBookingSystem.Repositories.Interfaces
{
	public interface ISpecialtyRepository 
	{
		Task<IEnumerable<Specialty>> GetAllAsync();
		Task<Specialty?> GetByIdAsync(int id);
		Task AddAsync(Specialty specialty);
		Task UpdateAsync(Specialty specialty);
		Task DeleteAsync(Specialty specialty);
		Task SaveAsync();
	}
}
