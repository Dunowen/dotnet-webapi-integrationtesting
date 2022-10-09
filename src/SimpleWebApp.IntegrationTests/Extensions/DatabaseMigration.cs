using Microsoft.EntityFrameworkCore;
using SimpleWebApp.Domain.Entities;
using SimpleWebApp.Persistence;

namespace SimpleWebApp.IntegrationTests.Extensions
{
	internal static class DatabaseMigration
	{
		public static async Task SeedDatabase(this DatabaseContext context)
		{
			await context.PruneDatabase();

			var users = new List<User> {
				new User("Stanley", 22),
				new User("Kevin", 25),
			};

			context.Users.AddRange(users);
			await context.SaveChangesAsync();
		}

		public static async Task PruneDatabase(this DatabaseContext context)
		{
			context.Users.RemoveRange(context.Users);
			await context.SaveChangesAsync();
		}
	}
}
