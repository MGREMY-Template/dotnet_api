namespace Domain.Mapper.Application;

using AutoMapper;
using Domain.DataTransferObject.Application;
using Domain.Entities.Application;

public class AppFileMapper : Profile
{
    public AppFileMapper()
    {
        _ = this.CreateMap<AppFile, AppFileDto>()
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
            x.CreationDate,
            opt =>
            {
                opt.MapFrom(src => src.CreationDate);
            })
        .ForMember(x =>
            x.Content,
            opt =>
            {
                opt.MapFrom(src => src.Content);
            })
        .ReverseMap();
    }
}
