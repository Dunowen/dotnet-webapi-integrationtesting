using Microsoft.EntityFrameworkCore;
using SimpleWebApp.Domain.Entities;

namespace SimpleWebApp.Persistence
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
	}
}