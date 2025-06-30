﻿using ClinicBookingSystem.Models;

namespace ClinicBookingSystem.Repositories.Interfaces
{
	public interface IAppointmentRepository
	{
		Task<IEnumerable<Appointment>> GetAllAsync();
		Task<Appointment?> GetByIdAsync(int id);
		Task AddAsync(Appointment appointment);
		Task UpdateAsync(Appointment appointment);
		Task DeleteAsync(Appointment appointment);
		Task SaveAsync();
	}
}
