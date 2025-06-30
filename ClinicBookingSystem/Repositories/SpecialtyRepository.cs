using ClinicBookingSystem.Data;
using ClinicBookingSystem.Models;
using ClinicBookingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem.Repositories
{
	public class SpecialtyRepository : ISpecialtyRepository
	{
		private readonly AppDbContext _context;

		public SpecialtyRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Specialty>> GetAllAsync()
		{
			return await _context.Specialties.ToListAsync();
		}

		public async Task<Specialty?> GetByIdAsync(int id)
		{
			return await _context.Specialties.FindAsync(id);
		}

		public async Task AddAsync(Specialty specialty)
		{
			await _context.Specialties.AddAsync(specialty);
		}

		public Task UpdateAsync(Specialty specialty)
		{
			_context.Specialties.Update(specialty);
			return Task.CompletedTask;
		}

		public Task DeleteAsync(Specialty specialty)
		{
			_context.Specialties.Remove(specialty);
			return Task.CompletedTask;
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
