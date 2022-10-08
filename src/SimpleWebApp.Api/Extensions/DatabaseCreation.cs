using SimpleWebApp.Domain.Entities;
using SimpleWebApp.Persistence;

namespace SimpleWebApp.Api.Extensions
{
	static class DatabaseCreation
	{
		internal static void CreateDatabase(this IServiceCollection services)
		{
			var sp = services.BuildServiceProvider();

			using var scope = sp.CreateScope();

			var scopedServices = scope.ServiceProvider;
			var db = scopedServices.GetRequiredService<DatabaseContext>();

			db.Database.EnsureCreatedAsync().Wait();

			if (!db.Users.Any())
			{
				db.Users.AddRange(new List<User>
				{
					new User("Jim", 33),
					new User("Dwight", 35),
					new User("Michael", 41),
					new User("Pam", 31),
				});

				db.SaveChangesAsync().Wait();
			}
		}
	}
}
