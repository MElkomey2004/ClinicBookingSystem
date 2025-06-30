using ClinicBookingSystem.Data;
using ClinicBookingSystem.Models;
using ClinicBookingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem.Repositories
{
	public class TimeSlotRepository : ITimeSlotRepository
	{
		private readonly AppDbContext _context;

		public TimeSlotRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<TimeSlot>> GetAllAsync()
		{
			return await _context.TimeSlots
				.Include(t => t.Doctor)
				.ToListAsync();
		}

		public async Task<TimeSlot?> GetByIdAsync(int id)
		{
			return await _context.TimeSlots
				.Include(t => t.Doctor)
				.FirstOrDefaultAsync(t => t.Id == id);
		}

		public async Task<IEnumerable<TimeSlot>> GetByDoctorIdAsync(int doctorId)
		{
			return await _context.TimeSlots
				.Where(t => t.DoctorId == doctorId)
				.ToListAsync();
		}

		public async Task AddAsync(TimeSlot timeSlot)
		{
			await _context.TimeSlots.AddAsync(timeSlot);
		}

		public void Update(TimeSlot timeSlot)
		{
			_context.TimeSlots.Update(timeSlot);
		}

		public void Delete(TimeSlot timeSlot)
		{
			_context.TimeSlots.Remove(timeSlot);
		}

		public async Task<bool> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
