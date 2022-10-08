using Microsoft.EntityFrameworkCore;
using SimpleWebApp.Domain.Entities;
using SimpleWebApp.Persistence.Repositories.Interfaces;

namespace SimpleWebApp.Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DatabaseContext _databaseContext;

		public UserRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public async Task<List<User>> GetUsersAsync()
		{
			var users = await _databaseContext.Users.ToListAsync();

			return users;
		}

		public async Task<User> CreateUserAsync(User user)
		{
			_databaseContext.Set<User>().Add(user);
			await _databaseContext.SaveChangesAsync();

			return user;
		}
	}
}
