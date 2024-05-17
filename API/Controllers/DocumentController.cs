using CoreApiResponse;
using Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;

namespace API.Controllers;

[Route("api/documents")]
[ApiController]
public class DocumentController(IMediator _mediator) : BaseController
{
    [HttpPost, DisableRequestSizeLimit]
    public async Task<IActionResult> Upload()
    {
        var formCollection = await Request.ReadFormAsync();
        var file = formCollection.Files[0];

        var folderName = Path.Combine("Resources", "Documents");

        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        var fullPath = Path.Combine(pathToSave, fileName);
        var dbPath = Path.Combine(folderName, fileName);
        using (FileStream stream = new(fullPath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        await _mediator.Publish(new FileUploadedEvent(dbPath));

        return CustomResult("File has been uploaded successfully", new { dbPath }, HttpStatusCode.OK);
    }
}