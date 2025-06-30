using AutoMapper;
using ClinicBookingSystem.DTOs.TimeSlot;
using ClinicBookingSystem.Models;
using ClinicBookingSystem.Repositories.Interfaces;
using ClinicBookingSystem.Services.Interfaces;

namespace ClinicBookingSystem.Services
{
	public class TimeSlotService : ITimeSlotService
	{
		private readonly ITimeSlotRepository _repository;
		private readonly IMapper _mapper;

		public TimeSlotService(ITimeSlotRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<TimeSlotDto>> GetAllAsync()
		{
			var slots = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<TimeSlotDto>>(slots);
		}

		public async Task<TimeSlotDto?> GetByIdAsync(int id)
		{
			var slot = await _repository.GetByIdAsync(id);
			return slot == null ? null : _mapper.Map<TimeSlotDto>(slot);
		}

		public async Task<IEnumerable<TimeSlotDto>> GetByDoctorIdAsync(int doctorId)
		{
			var slots = await _repository.GetByDoctorIdAsync(doctorId);
			return _mapper.Map<IEnumerable<TimeSlotDto>>(slots);
		}

		public async Task<TimeSlotDto> AddAsync(CreateTimeSlotDto dto)
		{
			var slot = _mapper.Map<TimeSlot>(dto);
			await _repository.AddAsync(slot);
			await _repository.SaveChangesAsync();
			return _mapper.Map<TimeSlotDto>(slot);
		}

		public async Task<bool> UpdateAsync(UpdateTimeSlotDto dto)
		{
			var existing = await _repository.GetByIdAsync(dto.Id);
			if (existing == null) return false;

			_mapper.Map(dto, existing);
			_repository.Update(existing);
			return await _repository.SaveChangesAsync();
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var existing = await _repository.GetByIdAsync(id);
			if (existing == null) return false;

			_repository.Delete(existing);
			return await _repository.SaveChangesAsync();
		}
	}
}
