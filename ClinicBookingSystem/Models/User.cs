﻿namespace ClinicBookingSystem.Models
{
	public class User
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public string Role { get; set; } = "Patient"; 
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public ICollection<Appointment>? Appointments { get; set; }
		public ICollection<Notification>? Notifications { get; set; }

	}
}
