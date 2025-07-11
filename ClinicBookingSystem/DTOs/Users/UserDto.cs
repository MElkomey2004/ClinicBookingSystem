﻿namespace ClinicBookingSystem.DTOs.Users
{
	public class UserDto
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Role { get; set; } = "Patient";
		public DateTime CreatedAt { get; set; }
	}
}
