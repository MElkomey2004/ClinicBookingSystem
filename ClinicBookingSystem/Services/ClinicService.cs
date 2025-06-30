using ClinicBookingSystem.Models;
using ClinicBookingSystem.Repositories.Interfaces;
using ClinicBookingSystem.Services.Interfaces;

namespace ClinicBookingSystem.Services
{
	public class ClinicService : IClinicService
	{
		private readonly IClinicRepository _repo;
		public ClinicService(IClinicRepository repo)
		{
			_repo = repo;
		}

		public Task<IEnumerable<Clinic>> GetAllAsync() => _repo.GetAllAsync();
		public Task<Clinic?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
		public Task AddAsync(Clinic clinic) => _repo.AddAsync(clinic);
		public Task UpdateAsync(Clinic clinic) => _repo.UpdateAsync(clinic);
		public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
	}
}
