using MediatR;

namespace Application.Features.CQRS.Commands;

public class RemoveMeetingCommandRequest:IRequest
{
 
    public int Id { get; set; }

    public RemoveMeetingCommandRequest(int id)
    {
        Id = id;
    }
}