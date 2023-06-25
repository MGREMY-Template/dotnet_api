namespace Domain.Mapper.Identity;

using AutoMapper;
using Domain.DataTransferObject.Identity;
using Domain.Entities.Identity;

public class UserClaimMapper : Profile
{
    public UserClaimMapper()
    {
        _ = this.CreateMap<UserClaim, UserClaimDto>()
            .ForMember(x =>
                x.Id,
                opt =>
                {
                    opt.MapFrom(src => src.Id);
                })
            .ForMember(x =>
                x.UserId,
                opt =>
                {
                    opt.MapFrom(src => src.UserId);
                })
            .ForMember(x =>
                x.ClaimType,
                opt =>
                {
                    opt.MapFrom(src => src.ClaimType);
                })
            .ForMember(x =>
                x.ClaimValue,
                opt =>
                {
                    opt.MapFrom(src => src.ClaimValue);
                })
            .ReverseMap();
    }
}
