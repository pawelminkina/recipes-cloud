using Application.Commands.AddPhoto;
using MediatR;
using Application.Commands.PhotoAdded;
using Microsoft.Azure.Functions.Worker;

namespace Serverless.Azure.Functions.Blob;

public class PhotoAdded
{
    private readonly IMediator _mediator;

    public PhotoAdded(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Function("PhotoAdded")]
    public async Task Run([BlobTrigger("photos/{name}", Connection = "AzureWebJobsStorage")] byte[] file, string name)
    {
        await _mediator.Send(new PhotoAddedCommand(name));
    }
}