using Application.Traffics.Commands.CreateTraffic;
using Application.Traffics.Commands.DeleteTraffic;
using Application.Traffics.Commands.UpdateTraffic;
using Application.Traffics.Queries.GetTrafficById;
using Application.Traffics.Queries.GetTraffics;
using CoreApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[Route("api/traffic")]
[ApiController]
public class TrafficController(IMediator _mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateTrafficCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return CustomResult("Success", response, HttpStatusCode.OK);
    }

    [HttpDelete("{sessionId}")]
    public async Task<IActionResult> Delete(string sessionId, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteTrafficCommand(sessionId), cancellationToken);
        return CustomResult("Success", response, HttpStatusCode.OK);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTrafficCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return CustomResult("Success", response, HttpStatusCode.OK);
    }

    [HttpGet]
    public async Task<IActionResult> GetTraffics(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetTrafficsQuery(), cancellationToken);
        return CustomResult("Success", response, HttpStatusCode.OK);
    }

    [HttpGet("{sessionId}")]
    public async Task<IActionResult> GetById(string sessionId, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetTrafficByIdQuery(sessionId), cancellationToken);
        return CustomResult("Success", response, HttpStatusCode.OK);
    }
}