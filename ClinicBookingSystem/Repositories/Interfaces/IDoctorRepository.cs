using ClinicBookingSystem.Models;

namespace ClinicBookingSystem.Repositories.Interfaces
{
	public interface IDoctorRepository
	{
		Task<IEnumerable<Doctor>> GetAllAsync();
		Task<Doctor?> GetByIdAsync(int id);
		Task AddAsync(Doctor doctor);
		Task UpdateAsync(Doctor doctor);
		Task DeleteAsync(Doctor doctor);
		Task SaveAsync();
	}
}
