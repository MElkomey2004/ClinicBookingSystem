using ClinicBookingSystem.DTOs.Appointment;

namespace ClinicBookingSystem.Services.Interfaces
{
	public interface IAppointmentService
	{
		Task<IEnumerable<AppointmentDto>> GetAllAsync();
		Task<AppointmentDto?> GetByIdAsync(int id);
		Task AddAsync(CreateAppointmentDto dto);
		Task UpdateAsync(UpdateAppointmentDto dto);
		Task DeleteAsync(int id);
	}
}
