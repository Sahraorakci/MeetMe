using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Dto;
using Application.Features.CQRS.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ClassLibraryApplication.Features.CQRS.Handlers;

public class CreateMeetingQueryHandler : IRequestHandler<CreateMeetingCommandRequest, CreatedMeetingDto>
{
    private readonly IRepository<Meeting> _repository;
    private readonly IMapper _mapper;

    public CreateMeetingQueryHandler(IRepository<Meeting> repository, IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreatedMeetingDto> Handle(CreateMeetingCommandRequest request,
        CancellationToken cancellationToken)
    {
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        var meeting = await _repository.CreateAsync(new Meeting()
        {
            CreatedUserId = 1,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            Description = request.Description,
            IsPublic = request.IsPublic,
            IsDeleted = false,
            CreatedTime = DateTime.Now
        });
        return _mapper.Map<CreatedMeetingDto>(meeting);
    }
}