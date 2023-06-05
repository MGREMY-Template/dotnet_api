namespace Domain.Mapper.Identity;

using AutoMapper;
using Domain.DataTransferObject.Identity;
using System.Security.Claims;

public class ClaimMapper : Profile
{
    public ClaimMapper()
    {
        _ = this.CreateMap<Claim, ClaimDto>()
            .ForMember(x =>
                x.Issuer,
                opt =>
                {
                    opt.MapFrom(src => src.Issuer);
                })
            .ForMember(x =>
                x.Type,
                opt =>
                {
                    opt.MapFrom(src => src.Type);
                })
            .ForMember(x =>
                x.Value,
                opt =>
                {
                    opt.MapFrom(src => src.Value);
                })
            .ReverseMap();
    }
}
