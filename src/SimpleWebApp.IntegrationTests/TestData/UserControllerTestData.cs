using SimpleWebApp.DTOs.Request;
using Xunit;

namespace SimpleWebApp.IntegrationTests.TestData
{
	public class UserControllerTestData
	{
		public class CreateUserInvalidData : TheoryData<UserRequestDto>
		{
			public CreateUserInvalidData()
			{
				Add(new UserRequestDto { Name = "Test 1", Age = 0 });
				Add(new UserRequestDto { Name = "Test 1", Age = -1 });
				Add(new UserRequestDto { Name = "Test 1", Age = 100 });
				Add(new UserRequestDto { Name = "Test 1", Age = 101 });

				Add(new UserRequestDto { Name = " ", Age = 5 });
				Add(new UserRequestDto { Name = "", Age = 5 });
				Add(new UserRequestDto { Name = String.Empty, Age = 5 });
			}
		}
	}
}
