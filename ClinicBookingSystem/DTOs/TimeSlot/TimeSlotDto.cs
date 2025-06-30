﻿namespace ClinicBookingSystem.DTOs.TimeSlot
{
	public class TimeSlotDto
	{
		public int Id { get; set; }
		public int DoctorId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public bool IsAvailable { get; set; }

	}
}
