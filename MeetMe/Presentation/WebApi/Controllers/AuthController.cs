using Application.Constants;
using Application.Features.CQRS.Queries;
using Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;


    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(CheckUserQueryRequest checkUserQueryRequest)
    {
       var checkUserResponseDto= await this._mediator.Send(checkUserQueryRequest);
       if (checkUserResponseDto.IsExist)
       {
           return Created("", JwtTokenGenerator.GenerateToken(checkUserResponseDto));

       }
       else
       {
           return BadRequest(AuthConstants.WrongUserInfo);
       }
    }
}