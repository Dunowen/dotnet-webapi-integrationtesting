using SimpleWebApp.DTOs.Request;
using SimpleWebApp.DTOs.Response;

namespace SimpleWebApp.Api.Services.Interfaces
{
	public interface IUserService
	{
		Task<List<UserResponseDto>> GetUsersAsync();
		Task<UserResponseDto> CreateUserAsync(UserRequestDto request);
	}
}
