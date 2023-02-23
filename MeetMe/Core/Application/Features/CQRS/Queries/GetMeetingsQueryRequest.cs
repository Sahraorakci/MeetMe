using Application.Dto;
using MediatR;

namespace Application.Features.CQRS.Queries;

public class GetMeetingsQueryRequest:IRequest<List<MeetingListDto>>
{
    
}