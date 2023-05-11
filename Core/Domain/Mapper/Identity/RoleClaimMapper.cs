namespace Domain.Mapper.Identity;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.Entities.Identity;

public class RoleClaimMapper : Profile
{
    public RoleClaimMapper()
    {
        _ = this.CreateMap<RoleClaim, RoleClaimDto>()
            .ForMember(x =>
                x.Id,
                opt =>
                {
                    opt.MapFrom(src => src.Id);
                })
            .ForMember(x =>
                x.RoleId,
                opt =>
                {
                    opt.MapFrom(src => src.RoleId);
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
