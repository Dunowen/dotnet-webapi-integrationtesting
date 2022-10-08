using AutoMapper;
using SimpleWebApp.Domain.Entities;
using SimpleWebApp.DTOs.Request;
using SimpleWebApp.DTOs.Response;

namespace SimpleWebApp.Api.Mapper
{
	public class UserMapperProfile : Profile
	{
		public UserMapperProfile()
		{
			CreateMap<UserRequestDto, User>().ConstructUsing((src) => new User(src.Name, src.Age));

			CreateMap<User, UserResponseDto>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));
		}
	}
}
