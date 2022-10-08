using Microsoft.AspNetCore.Mvc;
using SimpleWebApp.Api.Services.Interfaces;
using SimpleWebApp.DTOs.Request;

namespace SimpleWebApp.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet()]
		public async Task<ActionResult> GetUsers()
		{
			try
			{
				var result = await _userService.GetUsersAsync();

				return Ok(result);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPost()]
		public async Task<ActionResult> CreateUser([FromBody]UserRequestDto request)
		{
			try
			{
				var result = await _userService.CreateUserAsync(request);

				return Ok(result);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}