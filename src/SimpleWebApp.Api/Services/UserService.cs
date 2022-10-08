using AutoMapper;
using SimpleWebApp.Api.Services.Interfaces;
using SimpleWebApp.Domain.Entities;
using SimpleWebApp.DTOs.Request;
using SimpleWebApp.DTOs.Response;
using SimpleWebApp.Persistence.Repositories.Interfaces;

namespace SimpleWebApp.Api.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<List<UserResponseDto>> GetUsersAsync()
		{
			var users = await _userRepository.GetUsersAsync();

			var result = _mapper.Map<List<UserResponseDto>>(users);

			return result;
		}

		public async Task<UserResponseDto> CreateUserAsync(UserRequestDto request)
		{
			var user = _mapper.Map<User>(request);

			var entity = await _userRepository.CreateUserAsync(user);

			var result = _mapper.Map<UserResponseDto>(entity);

			return result;
		}
	}
}
