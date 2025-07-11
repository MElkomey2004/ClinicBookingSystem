﻿namespace ClinicBookingSystem.Models
{
	public class Clinic
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;

		public int SpecialtyId { get; set; }
		public Specialty Specialty { get; set; }

		public ICollection<Doctor>? Doctors { get; set; }
	}
}
