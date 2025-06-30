namespace ClinicBookingSystem.DTOs.Clinic
{
	public class CreateClinicDto
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Phone { get; set; }
		public int SpecialtyId { get; set; }
	}
}
