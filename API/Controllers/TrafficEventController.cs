using Application.TrafficEvents.Commands.CreateTrafficEvent;
using Application.TrafficEvents.Commands.DeleteTrafficEvent;
using Application.TrafficEvents.Commands.UpdateTrafficEvent;
using Application.TrafficEvents.Queries.GetTrafficEventById;
using Application.TrafficEvents.Queries.GetTrafficEvents;
using CoreApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[Route("api/traffic-event")]
[ApiController]
public class TrafficEventController(IMediator _mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateTrafficEventCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return CustomResult("Success", response, HttpStatusCode.OK);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteTrafficEventCommand(id), cancellationToken);
        return CustomResult("Success", response, HttpStatusCode.OK);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTrafficEventCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return CustomResult("Success", response, HttpStatusCode.OK);
    }

    [HttpGet]
    public async Task<IActionResult> GetTraffics(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetTrafficEventsQuery(), cancellationToken);
        return CustomResult("Success", response, HttpStatusCode.OK);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetTrafficEventByIdQuery(id), cancellationToken);
        return CustomResult("Success", response, HttpStatusCode.OK);
    }
}