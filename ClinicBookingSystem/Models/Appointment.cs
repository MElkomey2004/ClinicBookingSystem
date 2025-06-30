namespace ClinicBookingSystem.Models
{
	public class Appointment
	{
		public int Id { get; set; }

		public int PatientId { get; set; }
		public User? Patient { get; set; }

		public int DoctorId { get; set; }
		public Doctor? Doctor { get; set; }

		public int ClinicId { get; set; }
		public Clinic? Clinic { get; set; }

		public DateTime AppointmentDate { get; set; }

		public string Status { get; set; } = "Pending"; // e.g., Pending, Confirmed, Canceled
		public string? Notes { get; set; }
	}
}
