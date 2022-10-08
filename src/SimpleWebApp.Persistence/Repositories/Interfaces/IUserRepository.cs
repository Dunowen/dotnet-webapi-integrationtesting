using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.Persistence.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<List<User>> GetUsersAsync();
		Task<User> CreateUserAsync(User user);
	}
}
