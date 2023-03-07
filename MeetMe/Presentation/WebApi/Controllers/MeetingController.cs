using Application.Dto;
using Application.Features.CQRS.Commands;
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
 [HttpGet("remove-meeting/{id}" )]
 public async Task<IActionResult> RemoveMeeting(int id)
 {
  var meetings = await _mediator.Send(new GetMeetingsQueryRequest());
  return Ok(meetings);
  
 }
 
 [HttpPost("create-meeting")]
 public async Task<IActionResult> CreateMeeting(CreateMeetingCommandRequest request)
 {
  var meeting = await _mediator.Send(request);
  return Created("",meeting);
  
 }
 
}