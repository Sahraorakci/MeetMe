using Application.Dto;
using MediatR;

namespace Application.Features.CQRS.Commands;

public class RegisterUserCommandRequest : IRequest<CreatedUserDto?>
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Mail { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
}