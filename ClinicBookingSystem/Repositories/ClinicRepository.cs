using ClinicBookingSystem.Data;
using ClinicBookingSystem.Models;
using ClinicBookingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem.Repositories
{
	public class ClinicRepository : IClinicRepository
	{
		private readonly AppDbContext _context;
		public ClinicRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Clinic>> GetAllAsync()
			=> await _context.Clinics.ToListAsync();

		public async Task<Clinic?> GetByIdAsync(int id)
			=> await _context.Clinics.FindAsync(id);

		public async Task AddAsync(Clinic clinic)
		{
			_context.Clinics.Add(clinic);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Clinic clinic)
		{
			_context.Clinics.Update(clinic);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var clinic = await _context.Clinics.FindAsync(id);
			if (clinic is not null)
			{
				_context.Clinics.Remove(clinic);
				await _context.SaveChangesAsync();
			}
		}
	}
}
