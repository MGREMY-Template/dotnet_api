﻿namespace Domain.Mapper.Identity;

using AutoMapper;
using Domain.DataTransferObject;
using Domain.Entities.Identity;

public class RoleMapper : Profile
{
    public RoleMapper()
    {
        _ = this.CreateMap<Role, RoleDto>()
            .ForMember(x =>
                x.Id,
                opt =>
                {
                    opt.MapFrom(src => src.Id);
                })
            .ForMember(x =>
                x.Name,
                opt =>
                {
                    opt.MapFrom(src => src.Name);
                })
            .ReverseMap();
    }
}
