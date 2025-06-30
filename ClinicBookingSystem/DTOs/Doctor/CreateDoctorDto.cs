namespace ClinicBookingSystem.DTOs.Doctor
{
	public class CreateDoctorDto
	{
		public string FullName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string? Bio { get; set; }
		public int SpecialtyId { get; set; }
		public int? ClinicId { get; set; }
	}
}
