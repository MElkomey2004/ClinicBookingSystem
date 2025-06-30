namespace ClinicBookingSystem.DTOs.Appointment
{
	public class CreateAppointmentDto
	{
		public int PatientId { get; set; }
		public int DoctorId { get; set; }
		public int ClinicId { get; set; }
		public DateTime AppointmentDate { get; set; }
		public string? Notes { get; set; }
	}
}
