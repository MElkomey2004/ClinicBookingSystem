﻿namespace ClinicBookingSystem.Models
{
	public class Notification
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public User? User { get; set; }

		public string Message { get; set; } = string.Empty;
		public DateTime SentAt { get; set; } = DateTime.UtcNow;
		public bool IsRead { get; set; } = false;
	}
}
