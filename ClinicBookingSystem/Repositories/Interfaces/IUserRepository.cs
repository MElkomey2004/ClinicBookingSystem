using ClinicBookingSystem.Models;

namespace ClinicBookingSystem.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllAsync();
		Task<User?> GetByIdAsync(int id);
		Task AddAsync(User user);
		void Update(User user);
		void Delete(User user);
		Task<bool> SaveChangesAsync();
	}
}
