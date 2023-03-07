using Application.Dto;
using Application.Features.CQRS.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace ClassLibraryApplication.Features.CQRS.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest , CreatedUserDto?>
{
    private readonly IRepository<AppUser> _repository;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreatedUserDto?> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _repository.CreateAsync(new AppUser()
        {
            Name = request.Name,
            Surname = request.Surname,
            Mail = request.Mail,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password,
            IsDeleted = false,
            CreatedTime = DateTime.Now

        });
        return _mapper.Map<CreatedUserDto>(user);
    }
    
    
}