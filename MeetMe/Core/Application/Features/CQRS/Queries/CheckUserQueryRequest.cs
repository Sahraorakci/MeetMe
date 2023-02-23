using Application.Dto;
using MediatR;

namespace Application.Features.CQRS.Queries;

public class CheckUserQueryRequest: IRequest<CheckUserResponseDto>
{
    public string Mail { get; set; } = null!;
    public string Password { get; set; } = null!;
}