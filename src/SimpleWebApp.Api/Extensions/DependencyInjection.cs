using SimpleWebApp.Api.Services;
using SimpleWebApp.Api.Services.Interfaces;
using SimpleWebApp.Persistence.Repositories;
using SimpleWebApp.Persistence.Repositories.Interfaces;

namespace SimpleWebApp.Api.Extensions
{
	internal static class DependencyInjection
	{
		internal static void ConfigureDependencyInjection(this IServiceCollection services)
		{
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IUserRepository, UserRepository>();
		}
	}
}
