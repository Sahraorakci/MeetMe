using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class AppUserMapper : Profile
{
    public AppUserMapper()
    {
        this.CreateMap<AppUser, CreatedUserDto>().ReverseMap();
    }
    
}