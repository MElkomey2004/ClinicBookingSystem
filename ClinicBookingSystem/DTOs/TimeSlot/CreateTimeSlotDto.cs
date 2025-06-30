namespace ClinicBookingSystem.DTOs.TimeSlot
{
	public class CreateTimeSlotDto
	{
		public int DoctorId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
	}
}
