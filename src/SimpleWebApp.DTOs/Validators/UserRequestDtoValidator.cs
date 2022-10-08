using FluentValidation;
using SimpleWebApp.DTOs.Request;

namespace SimpleWebApp.DTOs.Validators
{
	public class UserRequestDtoValidator : AbstractValidator<UserRequestDto>
	{
		public UserRequestDtoValidator()
		{
			RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
			RuleFor(x => x.Age)
				.GreaterThan(0)
				.LessThan(100);
		}
	}
}
