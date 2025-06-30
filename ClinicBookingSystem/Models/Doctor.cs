namespace ClinicBookingSystem.Models
{
	public class Doctor
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public User? User { get; set; }

		public int SpecialtyId { get; set; }
		public Specialty? Specialty { get; set; }

		public int ClinicId { get; set; }
		public Clinic? Clinic { get; set; }

		public string Bio { get; set; } = string.Empty;

		public ICollection<Appointment>? Appointments { get; set; }
		public ICollection<TimeSlot>? TimeSlots { get; set; }
	}
}
