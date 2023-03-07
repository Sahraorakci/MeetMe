using Application.Dto;
using MediatR;

namespace Application.Features.CQRS.Commands;

public class CreateMeetingCommandRequest : IRequest<CreatedMeetingDto?>
{
    public DateTime StartTime { get; set; } 
    public DateTime EndTime { get; set; }
    public string? Description { get; set; }
    public bool IsPublic { get; set; }
}