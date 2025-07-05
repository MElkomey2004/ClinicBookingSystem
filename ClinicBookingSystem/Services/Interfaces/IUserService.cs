using ClinicBookingSystem.DTOs.Users;

namespace ClinicBookingSystem.Services.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<UserDto>> GetAllPatientsAsync();
		Task<UserDto?> GetByIdAsync(int id);
		Task<UserDto> AddAsync(CreateUserDto dto);
		Task<bool> UpdateAsync(UpdateUserDto dto);
		Task<bool> DeleteAsync(int id);
	}
}
