using ClinicBookingSystem.Data;
using ClinicBookingSystem.Models;
using ClinicBookingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem.Repositories
{
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly AppDbContext _context;
		public AppointmentRepository(AppDbContext context) => _context = context;

		public async Task<IEnumerable<Appointment>> GetAllAsync()
		{
			return await _context.Appointments
				.Include(a => a.Patient)
				.Include(a => a.Doctor)
				.Include(a => a.Clinic)
				.ToListAsync();
		}

		public async Task<Appointment?> GetByIdAsync(int id)
		{
			return await _context.Appointments
				.Include(a => a.Patient)
				.Include(a => a.Doctor)
				.Include(a => a.Clinic)
				.FirstOrDefaultAsync(a => a.Id == id);
		}

		public async Task AddAsync(Appointment appointment)
		{
			await _context.Appointments.AddAsync(appointment);
		}

		public Task UpdateAsync(Appointment appointment)
		{
			_context.Appointments.Update(appointment);
			return Task.CompletedTask;
		}

		public Task DeleteAsync(Appointment appointment)
		{
			_context.Appointments.Remove(appointment);
			return Task.CompletedTask;
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
