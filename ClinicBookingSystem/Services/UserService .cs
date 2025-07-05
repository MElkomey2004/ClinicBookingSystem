using AutoMapper;
using ClinicBookingSystem.DTOs.Users;
using ClinicBookingSystem.Models;
using ClinicBookingSystem.Repositories.Interfaces;
using ClinicBookingSystem.Services.Interfaces;

namespace ClinicBookingSystem.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _repository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<UserDto>> GetAllPatientsAsync()
		{
			var users = await _repository.GetAllAsync();
			var patients = users.Where(u => u.Role == "Patient");
			return _mapper.Map<IEnumerable<UserDto>>(patients);
		}

		public async Task<UserDto?> GetByIdAsync(int id)
		{
			var user = await _repository.GetByIdAsync(id);
			return user?.Role == "Patient" ? _mapper.Map<UserDto>(user) : null;
		}

		public async Task<UserDto> AddAsync(CreateUserDto dto)
		{
			var user = _mapper.Map<User>(dto);
			user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
			await _repository.AddAsync(user);
			await _repository.SaveChangesAsync();
			return _mapper.Map<UserDto>(user);
		}

		public async Task<bool> UpdateAsync(UpdateUserDto dto)
		{
			var user = await _repository.GetByIdAsync(dto.Id);
			if (user == null || user.Role != "Patient") return false;

			_mapper.Map(dto, user);
			user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
			_repository.Update(user);
			return await _repository.SaveChangesAsync();
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var user = await _repository.GetByIdAsync(id);
			if (user == null || user.Role != "Patient") return false;

			_repository.Delete(user);
			return await _repository.SaveChangesAsync();
		}
	}
}
