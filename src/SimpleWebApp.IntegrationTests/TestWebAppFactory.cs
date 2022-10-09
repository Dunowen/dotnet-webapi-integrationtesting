using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebApp.Api;
using SimpleWebApp.Persistence;

namespace SimpleWebApp.IntegrationTests
{
	public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
	{
		protected override async void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.ConfigureServices(async services =>
			{
				var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DatabaseContext>));

				if (descriptor != null) services.Remove(descriptor);

				services.AddDbContext<DatabaseContext>(options =>
				{
					options.UseInMemoryDatabase("InMemoryDatabase");
				});

				var sp = services.BuildServiceProvider();
				using var scope = sp.CreateScope();
				using var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

				await context.Database.EnsureCreatedAsync();
			});
		}
	}
}
