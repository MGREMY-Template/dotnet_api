namespace Domain.Mapper.Identity;

using AutoMapper;
using Domain.DataTransferObject.Identity.UserRoleController;
using Domain.Entities.Identity;

public class UserRoleMapper : Profile
{
    public UserRoleMapper()
    {
        _ = this.CreateMap<UserRole, UserRoleDto>()
            .ForMember(x =>
                x.RoleId,
                opt =>
                {
                    opt.MapFrom(src => src.RoleId);
                })
            .ForMember(x =>
                x.UserId,
                opt =>
                {
                    opt.MapFrom(src => src.UserId);
                })
            .ReverseMap();
    }
}
