using System.Runtime.CompilerServices;
using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MeetingMapper : Profile
{
    public MeetingMapper()
    {
        this.CreateMap<Meeting, MeetingListDto>().ReverseMap();
        this.CreateMap<Meeting, CreatedMeetingDto>().ReverseMap();
    }
}