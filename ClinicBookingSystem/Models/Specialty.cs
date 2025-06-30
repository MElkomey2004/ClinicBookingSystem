﻿namespace ClinicBookingSystem.Models
{
	public class Specialty
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public ICollection<Doctor>? Doctors { get; set; }

	}
}

