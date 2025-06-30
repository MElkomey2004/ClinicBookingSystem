using ClinicBookingSystem.Data;
using ClinicBookingSystem.Models;
using ClinicBookingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem.Repositories
{
	public class DoctorRepository : IDoctorRepository
	{
		private readonly AppDbContext _context;
		public DoctorRepository(AppDbContext context) => _context = context;

		public async Task<IEnumerable<Doctor>> GetAllAsync()
		{
			return await _context.Doctors
				.Include(d => d.Specialty)
				.Include(d => d.Clinic)
				.ToListAsync();
		}

		public async Task<Doctor?> GetByIdAsync(int id)
		{
			return await _context.Doctors
				.Include(d => d.Specialty)
				.Include(d => d.Clinic)
				.FirstOrDefaultAsync(d => d.Id == id);
		}

		public async Task AddAsync(Doctor doctor)
		{
			await _context.Doctors.AddAsync(doctor);
		}

		public Task UpdateAsync(Doctor doctor)
		{
			_context.Doctors.Update(doctor);
			return Task.CompletedTask;
		}

		public Task DeleteAsync(Doctor doctor)
		{
			_context.Doctors.Remove(doctor);
			return Task.CompletedTask;
		}

		public async Task SaveAsync() => await _context.SaveChangesAsync();
	}
}
