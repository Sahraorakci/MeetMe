using Application.Dto;
using Application.Features.CQRS.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace ClassLibraryApplication.Features.CQRS.Handlers;

public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto?>
{
    private readonly IRepository<AppUser> _repository;

    public CheckUserQueryHandler(IRepository<AppUser> repository)
    {
        _repository = repository;
    }

    public async Task<CheckUserResponseDto?> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
    {
        var checkUserResponseDto = new CheckUserResponseDto();
        var user = await this._repository.GetByFilterAsync(
            x => x.Mail == request.Mail && x.Password == request.Password);
        if (user == null)
        {
            checkUserResponseDto.IsExist = false;
        }
        else
        {
            checkUserResponseDto.IsExist = true;
            checkUserResponseDto.Mail = user.Mail;
            checkUserResponseDto.Id = user.Id;
        }

        return checkUserResponseDto;
    }
}