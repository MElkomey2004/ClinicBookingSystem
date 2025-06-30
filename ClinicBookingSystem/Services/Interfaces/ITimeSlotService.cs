using ClinicBookingSystem.DTOs.TimeSlot;

namespace ClinicBookingSystem.Services.Interfaces
{
	public interface ITimeSlotService
	{
		Task<IEnumerable<TimeSlotDto>> GetAllAsync();
		Task<TimeSlotDto?> GetByIdAsync(int id);
		Task<IEnumerable<TimeSlotDto>> GetByDoctorIdAsync(int doctorId);
		Task<TimeSlotDto> AddAsync(CreateTimeSlotDto dto);
		Task<bool> UpdateAsync(UpdateTimeSlotDto dto);
		Task<bool> DeleteAsync(int id);
	}
}
