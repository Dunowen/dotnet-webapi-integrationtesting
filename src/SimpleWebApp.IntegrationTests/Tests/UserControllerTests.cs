using System.Net;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebApp.Api;
using SimpleWebApp.Domain.Entities;
using SimpleWebApp.DTOs.Request;
using SimpleWebApp.IntegrationTests.Extensions;
using SimpleWebApp.IntegrationTests.TestData;
using SimpleWebApp.Persistence;
using Xunit;

[assembly: CollectionBehavior(MaxParallelThreads = 1)]
namespace SimpleWebApp.IntegrationTests.Tests
{
	public class UserControllerTests
	{
		public class GetUsers : IClassFixture<TestingWebAppFactory<Program>>
		{
			private const string URL = "api/user";

			private readonly HttpClient _client;
			private readonly DatabaseContext _context;

			public GetUsers(TestingWebAppFactory<Program> factory)
			{
				_client = factory.CreateClient();
				var scope = factory.Services.CreateScope();
				_context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
			}

			[Fact]
			public async Task ShouldSucceed_WhenUsersAreReturned()
			{
				await _context.SeedDatabase();

				var response = await _client.GetAsync<List<User>>(URL);

				Assert.Equal(HttpStatusCode.OK, response.StatusCode);
				Assert.IsType<List<User>>(response.Result);
				Assert.Equal(2, response.Result.Count);
			}

			[Fact]
			public async Task ShouldSucceed_WhenThereAreNoUsers()
			{
				await _context.PruneDatabase();

				var response = await _client.GetAsync<List<User>>(URL);

				Assert.Equal(HttpStatusCode.OK, response.StatusCode);
				Assert.Empty(response.Result);
			}
		}

		public class CreateUser : IClassFixture<TestingWebAppFactory<Program>>
		{
			private const string URL = "api/user";

			private readonly HttpClient _client;

			public CreateUser(TestingWebAppFactory<Program> factory)
			{
				_client = factory.CreateClient();
			}

			[Fact]
			public async Task ShouldSucceed_WhenRequestIsValid()
			{
				var request = new UserRequestDto { Name = "Test", Age = 32 };

				var response = await _client.PostAsync<User>(URL, request);

				Assert.Equal(HttpStatusCode.OK, response.StatusCode);
				Assert.IsType<User>(response.Result);
				Assert.Equal(request.Name, response.Result.Name);
				Assert.Equal(request.Age, response.Result.Age);
			}

			[Theory]
			[ClassData(typeof(UserControllerTestData.CreateUserInvalidData))]
			public async Task ShouldFail_WhenRequestIsInvalid(UserRequestDto request)
			{
				var response = await _client.PostAsync<User>(URL, request);

				Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
			}
		}
	}
}
