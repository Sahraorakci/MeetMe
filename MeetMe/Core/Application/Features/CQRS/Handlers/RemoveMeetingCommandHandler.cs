using Application.Features.CQRS.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace ClassLibraryApplication.Features.CQRS.Handlers;

public class RemoveMeetingCommandHandler:IRequestHandler<RemoveMeetingCommandRequest>
{
    private IRepository<Meeting> _repository;

    public RemoveMeetingCommandHandler(IRepository<Meeting> repository)
    {
        _repository = repository;
    }


    public async Task<Unit> Handle(RemoveMeetingCommandRequest request, CancellationToken cancellationToken)
    {
        var removedEntity = await _repository.GetByIdAsync(request.Id);
        if (removedEntity != null)
        {
            removedEntity.IsDeleted = true;
            removedEntity.DeletedTime=DateTime.Now;
            await _repository.UpdateAsync(removedEntity);
        }
        return Unit.Value;
    }
}