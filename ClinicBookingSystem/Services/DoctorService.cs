using ClinicBookingSystem.Models;
using ClinicBookingSystem.Repositories.Interfaces;
using ClinicBookingSystem.Services.Interfaces;

namespace ClinicBookingSystem.Services
{
	public class DoctorService : IDoctorService
	{
		private readonly IDoctorRepository _repo;
		public DoctorService(IDoctorRepository repo) => _repo = repo;

		public async Task<IEnumerable<Doctor>> GetAllAsync()
			=> await _repo.GetAllAsync();

		public async Task<Doctor?> GetByIdAsync(int id)
			=> await _repo.GetByIdAsync(id);

		public async Task AddAsync(Doctor doctor)
		{
			await _repo.AddAsync(doctor);
			await _repo.SaveAsync();
		}

		public async Task UpdateAsync(Doctor doctor)
		{
			await _repo.UpdateAsync(doctor);
			await _repo.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var doctor = await _repo.GetByIdAsync(id);
			if (doctor != null)
			{
				await _repo.DeleteAsync(doctor);
				await _repo.SaveAsync();
			}
		}
	}
}
