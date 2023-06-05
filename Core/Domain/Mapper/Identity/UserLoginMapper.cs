namespace Domain.Mapper.Identity;

using AutoMapper;
using Domain.DataTransferObject.Identity;
using Domain.Entities.Identity;

public class UserLoginMapper : Profile
{
    public UserLoginMapper()
    {
        _ = this.CreateMap<UserLogin, UserLoginDto>()
            .ForMember(x =>
                x.UserId,
                opt =>
                {
                    opt.MapFrom(src => src.UserId);
                })
            .ForMember(x =>
                x.LoginProvider,
                opt =>
                {
                    opt.MapFrom(src => src.LoginProvider);
                })
            .ForMember(x =>
                x.ProviderKey,
                opt =>
                {
                    opt.MapFrom(src => src.ProviderKey);
                })
            .ForMember(x =>
                x.ProviderDisplayName,
                opt =>
                {
                    opt.MapFrom(src => src.ProviderDisplayName);
                })
            .ReverseMap();
    }
}
