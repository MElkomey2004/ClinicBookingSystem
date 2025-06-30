using ClinicBookingSystem.Models;

namespace ClinicBookingSystem.Repositories.Interfaces
{
	public interface ITimeSlotRepository
	{
		Task<IEnumerable<TimeSlot>> GetAllAsync();
		Task<TimeSlot?> GetByIdAsync(int id);
		Task<IEnumerable<TimeSlot>> GetByDoctorIdAsync(int doctorId);
		Task AddAsync(TimeSlot timeSlot);
		void Update(TimeSlot timeSlot);
		void Delete(TimeSlot timeSlot);
		Task<bool> SaveChangesAsync();
	}
}
