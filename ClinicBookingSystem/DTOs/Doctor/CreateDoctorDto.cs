namespace ClinicBookingSystem.DTOs.Doctor
{
	public class CreateDoctorDto
	{
		public string UserId { get; set; }
		public int SpecialtyId { get; set; }
		public int ClinicId { get; set; }
		public string Bio { get; set; } = string.Empty;
	}
}
