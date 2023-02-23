using Application.Dto;
using Application.Features.CQRS.Queries;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers;

public class GetMeetingsQueryHandler : IRequestHandler<GetMeetingsQueryRequest,List<MeetingListDto>>
{
    private readonly IRepository<Meeting> _repository;
    private readonly IMapper _mapper;

    public GetMeetingsQueryHandler(IRepository<Meeting> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<MeetingListDto>> Handle(GetMeetingsQueryRequest request, CancellationToken cancellationToken)
    {
       var meetings = await _repository.GetAllAsync();
       return this._mapper.Map<List<MeetingListDto>>(meetings);


    }
}