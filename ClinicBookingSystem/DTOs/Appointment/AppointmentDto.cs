namespace ClinicBookingSystem.DTOs.Appointment
{
	public class AppointmentDto
	{
		public int Id { get; set; }
		public string PatientName { get; set; } = string.Empty;
		public string DoctorName { get; set; } = string.Empty;
		public string ClinicName { get; set; } = string.Empty;
		public DateTime AppointmentDate { get; set; }
		public string Status { get; set; } = string.Empty;
		public string? Notes { get; set; }
	}
}
