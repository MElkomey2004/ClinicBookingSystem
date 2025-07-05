﻿using System.ComponentModel.DataAnnotations;

namespace ClinicBookingSystem.DTOs.Auth
{
	public class RegisterRequestDTO
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string UserName { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public List<string>?  Roles { get; set; }
	}
}
