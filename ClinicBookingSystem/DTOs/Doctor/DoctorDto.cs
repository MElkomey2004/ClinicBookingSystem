namespace ClinicBookingSystem.DTOs.Doctor
{
	public class DoctorDto
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string? Bio { get; set; }
		public string SpecialtyName { get; set; } = string.Empty;
		public string? ClinicName { get; set; }
	}
}
