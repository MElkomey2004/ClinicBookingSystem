using AutoMapper;
using ClinicBookingSystem.DTOs.Appointment;
using ClinicBookingSystem.Models;
using ClinicBookingSystem.Repositories.Interfaces;
using ClinicBookingSystem.Services.Interfaces;

namespace ClinicBookingSystem.Services
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IAppointmentRepository _repo;
		private readonly IMapper _mapper;

		public AppointmentService(IAppointmentRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
		{
			var appointments = await _repo.GetAllAsync();
			return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
		}

		public async Task<AppointmentDto?> GetByIdAsync(int id)
		{
			var appointment = await _repo.GetByIdAsync(id);
			return appointment == null ? null : _mapper.Map<AppointmentDto>(appointment);
		}

		public async Task AddAsync(CreateAppointmentDto dto)
		{
			var appointment = _mapper.Map<Appointment>(dto);
			await _repo.AddAsync(appointment);
			await _repo.SaveAsync();
		}

		public async Task UpdateAsync(UpdateAppointmentDto dto)
		{
			var existing = await _repo.GetByIdAsync(dto.Id);
			if (existing == null) return;

			_mapper.Map(dto, existing);
			await _repo.UpdateAsync(existing);
			await _repo.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var appointment = await _repo.GetByIdAsync(id);
			if (appointment != null)
			{
				await _repo.DeleteAsync(appointment);
				await _repo.SaveAsync();
			}
		}
	}
}
