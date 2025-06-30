using ClinicBookingSystem.Models;
using ClinicBookingSystem.Repositories.Interfaces;
using ClinicBookingSystem.Services.Interfaces;

namespace ClinicBookingSystem.Services
{
	public class SpecialtyService : ISpecialtyService
	{

		private readonly ISpecialtyRepository _repo;

		public SpecialtyService(ISpecialtyRepository repo)
		{
			_repo = repo;
		}

		public async Task<IEnumerable<Specialty>> GetAllAsync()
			=> await _repo.GetAllAsync();

		public async Task<Specialty?> GetByIdAsync(int id)
			=> await _repo.GetByIdAsync(id);

		public async Task AddAsync(Specialty specialty)
		{
			await _repo.AddAsync(specialty);
			await _repo.SaveAsync();
		}

		public async Task UpdateAsync(Specialty specialty)
		{
			await _repo.UpdateAsync(specialty);
			await _repo.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var specialty = await _repo.GetByIdAsync(id);
			if (specialty != null)
			{
				await _repo.DeleteAsync(specialty);
				await _repo.SaveAsync();
			}
		}
	}
}
