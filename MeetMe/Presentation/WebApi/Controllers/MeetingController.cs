using Application.Dto;
using Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MeetingController : ControllerBase
{
 private readonly IMediator _mediator;

 public MeetingController(IMediator mediator)
 {
  _mediator = mediator;
 }

 [HttpGet("get-all-meeting")]
 public async Task<IActionResult> GetAllMeeting()
 {
  var meetings = await _mediator.Send(new GetMeetingsQueryRequest());
  return Ok(meetings);
  
 }
 
}