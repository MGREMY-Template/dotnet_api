namespace Shared.Core.Mapper.Identity;

using AutoMapper;
using Shared.Core.DataTransferObject.Identity.UserController;
using Shared.Core.Entities.Identity;

public class UserMapper : Profile
{
    public UserMapper()
    {
        _ = this.CreateMap<User, UserDto>()
            .ForMember(x =>
                x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(x =>
                x.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(x =>
                x.UserName,
                opt => opt.MapFrom(src => src.UserName))
            .ReverseMap();
    }
}
