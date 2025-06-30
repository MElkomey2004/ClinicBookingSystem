namespace ClinicBookingSystem.DTOs.Appointment
{
	public class UpdateAppointmentDto : CreateAppointmentDto
	{
		public int Id { get; set; }
		public string Status { get; set; } = "Pending";
	}
}
